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
            //need to add some sort of loading screen cause this takes a bit of time

            if (filePath.Contains(".mp3"))
            {
                //convert mp3 to wav - not required currently
            }

            var newFilePath = filePath + "m.wav"; //have to create new file, not sure how to only create it temporarily until its processed
            audioProcessor.ConvertStereoToMono(filePath, newFilePath);

            // AuthExplicit("speech2text-1581342315295", "D:/projects/SpeechToText/S2TPrivateKey.json");
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
    }
}
