using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        private string filePath = string.Empty;
        private string transcribedText = "";

        public Form1()
        {
            InitializeComponent();
            voiceModelDropdown.SelectedIndex = 0; //default dropdown values
            enableAutoPunctuationDropdown.SelectedIndex = 0;
        }

        public object AuthExplicit(string projectId, string jsonPath) //only used at first for testing
        {
            //used for checking the authentication to Google services
            // Explicitly use service account credentials by specifying 
            // the private key file.
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
            using(OpenFileDialog dialog = new OpenFileDialog())
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



        private void transcribeBtn_Click(object sender, EventArgs e)
        {
            /*TODO:
             * Convert the audio recognition to an async request to bypass the 1 minute limit 
             * use an uri pointing to google cloud storage holding the file to be processed, 
             * because files between 1 minute and 480 minutes must be retrieved from google cloud rather than local storage
             */
            processingLabel.Visible = true;
            //need to add some sort of loading screen cause this takes a bit of time

            if (filePath.Contains(".mp3"))
            {
                //convert mp3 to wav - not required currently
            }

            var newFilePath = filePath + "m.wav"; //have to create new file, not sure how to only create it temporarily until its processed
            audioProcessor.ConvertStereoToMono(filePath, newFilePath);

            if(audioProcessor.getDuration(filePath) > new TimeSpan(0, 1, 0))
            {
                //process long audio
                asyncTranscribe("gs://s2t-test-bucket1/speech.mp3m.wav");
            }

            else
            {
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
            }

            saveTranscriptBtn.Enabled = true;
            processingLabel.Visible = false;
            File.Delete(newFilePath);
        }

        static object asyncTranscribe(string storageUri)
        {
            var thisForm = new Form1();
            var speech = SpeechClient.Create();
            var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                Model = thisForm.voiceModelDropdown.SelectedItem.ToString(),
                EnableAutomaticPunctuation = thisForm.enableAutoPunctuationDropdown.SelectedItem.ToString() == "Yes" ? true : false,//true if yes selected
                 // SampleRateHertz = processor.getSampleRate(filePath),      //another customisable option
                LanguageCode = thisForm.languageCodeBox.Text.ToString(),
                //maxAlternatives, profanityFilter, speechContext
            }, RecognitionAudio.FromStorageUri(storageUri));
            longOperation = longOperation.PollUntilCompleted();
            var response = longOperation.Result;
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                  //  MessageBox.Show(result.Alternatives.ToString());

               //     thisForm.richTextBox1.Text = alternative.Transcript.ToString();
                 //   thisForm.transcribedText += alternative.Transcript;

                //    File.WriteAllText(Environment.SpecialFolder.Desktop.ToString(), alternative.Transcript);
                }
            }
            return 0;
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
