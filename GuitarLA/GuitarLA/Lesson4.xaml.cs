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
	public partial class Lesson4 : ContentPage
	{
		public Lesson4 ()
		{
			InitializeComponent ();
		}
        private async void ToAccordA(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Acc.accordA());
        }
        private async void ToAccordAm(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Acc.accordAm());
        }
        private async void ToAccordDm(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Acc.accordDm());
        }
        private async void ToAccordE(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Acc.accordE());
        }
        private async void ToAccordG(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Acc.accordG());
        }
    }
}