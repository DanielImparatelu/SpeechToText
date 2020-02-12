using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToText
{
    class SoundRecorder
    {
        public WaveIn waveSource = null;
        public WaveFileWriter waveFile = null;

        public void startRecording(string saveLocation)
        {
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

            waveFile = new WaveFileWriter(@saveLocation, waveSource.WaveFormat);

            waveSource.StartRecording();
        }

        public void stopRecording()
        {
            waveSource.StopRecording();
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }
























        //[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        //public void startRecording()
        //{
        //    mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
        //    mciSendString("record recsound", "", 0, 0);
        //    Console.WriteLine("recording, press Enter to stop and save ...");
        //    Console.ReadLine();

        //    mciSendString("save recsound c:\\work\\result.wav", "", 0, 0);
        //    mciSendString("close recsound ", "", 0, 0);
        //}
    }
}
