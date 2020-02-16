using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Google.Cloud.Storage.V1;
using Grpc.Auth;
using NAudio.Wave;

namespace SpeechToText
{
    public partial class Form1 : Form
    {
        private AudioProcessor audioProcessor = new AudioProcessor();
        private SoundRecorder recorder = new SoundRecorder();
        private GCErrorReporting cloudErrors = new GCErrorReporting();
        private string filePath = string.Empty;
        private string transcribedText = "";
        private string URIString = "";
        private string newFilePath = "";

        public Form1()
        {
            InitializeComponent();
            voiceModelDropdown.SelectedIndex = 0; //default dropdown values
            enableAutoPunctuationDropdown.SelectedIndex = 0;
        }

        public object AuthExplicit(string projectId, string jsonPath) //only used at first for testing
        {
            //used for checking the authentication to Google services
            // Explicitly use service account credentials by specifying  the private key file.
            var credential = GoogleCredential.FromFile(jsonPath);
            var storage = StorageClient.Create(credential);
            // Make an authenticated API request.
            var buckets = storage.ListBuckets(projectId);
            foreach (var bucket in buckets)
            {
                richTextBox1.Text = bucket.Name;
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)//add audio file from system
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = "C:\\";
                dialog.Filter = "Audio files (*.mp3)|*.mp3;*.m4a;*.wav;*.ogg";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = dialog.FileName;
                    fileSelectedLabel.Text = filePath;//show what file we selected

                    transcribeBtn.Enabled = true;
                }
            }
        }

        private void addUriBtn_Click(object sender, EventArgs e)
        {
            URIString = addURIText.Text.ToString();
            transcribeBtn.Enabled = true;
        }

        private void transcribeBtn_Click(object sender, EventArgs e)
        {
            processingLabel.Visible = true;
            //need to add some sort of loading screen cause this takes a bit of time

            if (filePath.Contains(".mp3"))
            {
                //convert mp3 to wav - not required currently
            }

            newFilePath = filePath + "m.wav"; //have to create new file, but it will be deleted after it's used

            if (URIString == "")
            {
                if (audioProcessor.getDuration(filePath) <= new TimeSpan(0, 1, 0))
                {
                    audioProcessor.ConvertStereoToMono(filePath, newFilePath); //usually files are recorded stereo, we need mono here

                    var speech = SpeechClient.Create();
                    var response = speech.Recognize(new RecognitionConfig()
                    {
                        Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                        Model = voiceModelDropdown.SelectedItem.ToString(),
                        EnableAutomaticPunctuation = enableAutoPunctuationDropdown.SelectedItem.ToString() == "Yes" ? true : false,//true if yes selected
                                                                                                                                   // SampleRateHertz = processor.getSampleRate(filePath),      //another customisable option
                        LanguageCode = languageCodeBox.Text.ToString(),
                        //maxAlternatives, profanityFilter, speechContext
                    }, RecognitionAudio.FromFile(newFilePath));

                    foreach (var result in response.Results)
                    {
                        foreach (var alternative in result.Alternatives)
                        {
                            richTextBox1.Text = alternative.Transcript;
                            transcribedText += alternative.Transcript;
                        }
                    }
                    saveTranscriptBtn.Enabled = true;
                    processingLabel.Visible = false;
                }

                else //if file is longer than 1 minute
                {
                    MessageBox.Show("File is longer than 1 minute, please upload the file to Google Cloud and use an URI to access it");
                    transcribeBtn.Enabled = false;
                    processingLabel.Visible = false;
                }
            }

            else //if URI string has been provided
            {
                try
                {
                    // asyncTranscribe(URIString);
                    AsyncRecognizeGcs(URIString);
                    //"gs://s2t-test-bucket1/speech.mp3m.wav"
                }
                catch (UriFormatException UriException)
                {
                    //write to an error log maybe
                    MessageBox.Show("Invalid URI string");
                    cloudErrors.report(UriException);
                   
                }
            }

            File.Delete(newFilePath);
        }

        object AsyncRecognizeGcs(string storageUri)
        {
            try
            {
                var speech = SpeechClient.Create();
                var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    Model = voiceModelDropdown.SelectedItem.ToString(),
                    EnableAutomaticPunctuation = enableAutoPunctuationDropdown.SelectedItem.ToString() == "Yes" ? true : false,//true if yes selected
                                                                                                                               // SampleRateHertz = processor.getSampleRate(filePath),      //another customisable option
                    LanguageCode = languageCodeBox.Text.ToString(),
                }, RecognitionAudio.FromStorageUri(storageUri));
                longOperation = longOperation.PollUntilCompleted();
                var response = longOperation.Result;
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        richTextBox1.Text = alternative.Transcript;
                        richTextBox1.BeginInvoke((MethodInvoker)delegate { richTextBox1.AppendText(alternative.Transcript); }); //delegate to write to a control from different thread
                        transcribedText += alternative.Transcript;
                        Console.WriteLine($"Transcript: { alternative.Transcript}");
                    }
                }
                processingLabel.Visible = false;
                saveTranscriptBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured, see the cloud error reporting page for details");
                cloudErrors.report(ex);
            }

            return 0;
        }


        static async Task writeToFileAsync(string dir, string file, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file)))
            {
                await outputFile.WriteAsync(content);
            }
        }

        private void saveTranscriptBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.FileName = "transcription.txt";
                dialog.InitialDirectory = "C:\\";
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dialog.FileName, transcribedText);
                }
            }
        }

        private void startRecordingBtn_Click(object sender, EventArgs e)
        {
            /*
             * HARDCODED TEMP LOCATION!!! REMEMBER TO CHANGE!!!
             */
            var saveLocation = "../../../testrec.wav";

            startRecordingBtn.Visible = false;
            stopRecordingBtn.Visible = true;
            labelRecording.Visible = true;
            recorder.startRecording(saveLocation);
        }

        private void stopRecordingBtn_Click(object sender, EventArgs e)
        {
            stopRecordingBtn.Visible = false;
            startRecordingBtn.Visible = true;
            labelRecording.Visible = false;

            recorder.stopRecording();
        }


    }
}
