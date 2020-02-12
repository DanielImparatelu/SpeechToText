using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechToText
{
    class AudioProcessor
    {

        public void ConvertMp3ToWav(string sourceFile, string outputFile)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(sourceFile))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(outputFile, pcm);
                }
            }
        }

        public void ConvertStereoToMono(string sourceFile, string outputFile)
        {
            using (var waveFileReader = new AudioFileReader(sourceFile))
            {
                var outFormat = new WaveFormat(waveFileReader.WaveFormat.SampleRate, 1);
                using (var resampler = new MediaFoundationResampler(waveFileReader, outFormat))
                {
              //      MessageBox.Show("wave format: " + resampler.WaveFormat.ToString() + "\nsample rate: " + waveFileReader.WaveFormat.SampleRate.ToString());
                    WaveFileWriter.CreateWaveFile(outputFile, resampler);
                }
            }
        }

        public int getSampleRate(string sourceFile)
        {
            //if specified in the RecognitionConfig, the sample rate of the audio file must match the sample rate spec
            using (var waveFileReader = new AudioFileReader(sourceFile))
            {
                var sampleRate = waveFileReader.WaveFormat.SampleRate;
                return sampleRate;
            }
        }
    }
}
