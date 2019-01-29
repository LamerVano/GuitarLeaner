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
	public partial class Lesson3 : ContentPage
	{
		public Lesson3 ()
		{
			InitializeComponent ();
		}
        private async void ToTunerPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TunerPage());
        }
    }
}