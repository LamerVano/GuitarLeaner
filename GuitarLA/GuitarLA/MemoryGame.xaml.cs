using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Media;
using System;

namespace GuitarLA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MemoryGame : ContentPage
	{
        bool _inProgress = true;
        sbyte[] _Accord;
        double[] _Frequency = new double[] { 82.41, 110, 146.83, 196, 246.94, 329.63 };
        Thread thread;
        Stack<string> _gameStack;
        string playNow;
        public MemoryGame (Stack<string> gameStack)
		{
			InitializeComponent ();
            _gameStack = gameStack;
            playNow = _gameStack.Pop();
            Accord.Text = playNow;
            
            thread = new Thread(Compare);
            thread.Start();
        }
        private void Compare()
        {
            int Length = 4096*2;
            int bufLenght = Length * 8;
            short[] audioBufer = new short[bufLenght];
            int sample = 44100;
            AudioRecord record;
            try
            {
                record = new AudioRecord(AudioSource.Mic, sample, ChannelIn.Front, Android.Media.Encoding.Pcm16bit, Length);
                record.StartRecording();
                record.Stop();
            }
            catch(Exception e)
            {
                Length *= 2;
            }
            record = new AudioRecord(AudioSource.Mic, sample, ChannelIn.Front, Android.Media.Encoding.Pcm16bit, Length);
            while (_inProgress)
            {
                record.StartRecording();
                record.Read(audioBufer, 0, Length);
                record.Stop();
                for (int i = 0; i < Length; i++)
                    audioBufer[i] = (short)(audioBufer[i] * FFT.Gausse(i, bufLenght));
                Complex[] ComplexMagn = FFT.Fft(audioBufer);
                for (int i = 0; i < bufLenght; i++)
                    ComplexMagn[i] /= Length;
                double[] magnitude = FFT.ToArray(ComplexMagn);
                _Accord = App.Database.GetItemOnSByte(playNow);
                bool isTrues = Analyse.IsEquals(magnitude, _Accord, _Frequency);
                if (isTrues)
                {
                    Accord.Text = "Right";
                    Device.BeginInvokeOnMainThread(Next);
                }
            }
        }
        private void Next()
        {
            if (_gameStack.Count != 0)
            {
                playNow = _gameStack.Pop();
                Accord.Text = playNow;
            }
            else
                ToPractisePage();
        }
        private async void ToPractisePage()
        {
            _inProgress = false;
            await Navigation.PushAsync(new PractisePage());
        }
    }
}