using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitarLA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TunerPage : ContentPage
	{
        double _Frequency;
        double _FreqDiff = 0;
        bool _inProgress = true;
        Thread thread;
        public TunerPage()
        {
            InitializeComponent();
            thread = new Thread(Compare);
            thread.Start();
        }
        private void E1_Click(object s, EventArgs e)
        {
            _Frequency = 82.41;
        }
        private void A_Click(object s, EventArgs e)
        {
            _Frequency = 110;
        }
        private void D_Click(object s, EventArgs e)
        {
            _Frequency = 146.83;
        }
        private void G_Click(object s, EventArgs e)
        {
            _Frequency = 196;
        }
        private void H_Click(object s, EventArgs e)
        {
            _Frequency = 246.94;
        }
        private void E2_Click(object s, EventArgs e)
        {
            _Frequency = 329.63;
        }
        private void Stop_Click(object s, EventArgs e)
        {
            _inProgress = false;
        }
        private void Compare()
        {
            int Length = 4096;
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
            catch (Exception e)
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
                double peak = Analyse.FindPeak(magnitude) * sample / bufLenght;
                _FreqDiff = peak - Analyse.Octave(peak, _Frequency);
                Device.BeginInvokeOnMainThread(Change);
            }
        }
        private void Change()
        {
            label.Text = _FreqDiff.ToString();
        }
        private async void ToMainPage(object sender, EventArgs e)
        {
            _inProgress = false;
            await Navigation.PushAsync(new MainPage());
        }
    }
}