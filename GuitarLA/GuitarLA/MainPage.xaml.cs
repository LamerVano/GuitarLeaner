using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuitarLA
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private async void ToTunerPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TunerPage());
        }
        private async void ToLearningPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LearningPage());
        }
        private async void ToPractisePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PractisePage());
        }
        public void ToCloseOne(object sender, EventArgs e)
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}
