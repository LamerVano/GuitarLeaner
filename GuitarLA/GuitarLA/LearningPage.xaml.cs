using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitarLA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LearningPage : ContentPage
	{
		public LearningPage ()
		{
			InitializeComponent ();
		}
        private async void ToLesson1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lesson1());
        }
        private async void ToLesson2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lesson2());
        }
        private async void ToLesson3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lesson3());
        }
        private async void ToLesson4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lesson4());
        }
        private async void ToLesson5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lesson5());
        }
        private async void ToLesson6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lesson6());
        }
        private async void ToPractisePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PractisePage());
        }
        private async void ToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}