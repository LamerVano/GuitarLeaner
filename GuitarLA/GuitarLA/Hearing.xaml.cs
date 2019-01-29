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
	public partial class Hearing : ContentPage
	{
        public Stack<string> some;
        public string[] checkBox;
        public string playNow;
        public string[] check;
        public string accord_code;

        public Hearing(Stack<string> gameStackkk)
        {
            InitializeComponent();
            checkBox = new string[] { "0", "1", "2", "3", "4", "5", "6" };
            check = new string[] { "-1", "-1", "-1", "-1", "-1", "-1" };
            accord1.ItemsSource = checkBox;
            accord2.ItemsSource = checkBox;
            accord3.ItemsSource = checkBox;
            accord4.ItemsSource = checkBox;
            accord5.ItemsSource = checkBox;
            accord6.ItemsSource = checkBox;
            playNow = gameStackkk.Pop();
            some = gameStackkk;

            accord_code = App.Database.GetItem(playNow);
            playNow += ".m4a";
            DependencyService.Get<IAudio>().PlayAudioFile(playNow);
        }

        public void repAudio(object sender, EventArgs e)
        {
            DependencyService.Get<IAudio>().PlayAudioFile(playNow);
        }

        private void accord1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                check[0] = e.SelectedItem.ToString();
        }
        private void accord2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                check[1] = e.SelectedItem.ToString();
        }
        private void accord3_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                check[2] = e.SelectedItem.ToString();
        }
        private void accord4_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                check[3] = e.SelectedItem.ToString();
        }
        private void accord5_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                check[4] = e.SelectedItem.ToString();
        }
        private void accord6_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                check[5] = e.SelectedItem.ToString();
        }
        private void ClearAll(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
                check[i] = "-1";
            accord1.SelectedItem = null;
            accord2.SelectedItem = null;
            accord3.SelectedItem = null;
            accord4.SelectedItem = null;
            accord5.SelectedItem = null;
            accord6.SelectedItem = null;
        }
        private async void Setup(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 0; i < check.Length; i++)
            {
                result += check[i];
            }

            if (result == accord_code)
            {
                checkResult.Text = "RIGHT";
                checkResult.TextColor = Color.Green;
                if (some.Count != 0)
                {
                    await Navigation.PushAsync(new Hearing(some));
                }
                else
                {
                    await Navigation.PushAsync(new PractisePage());
                }
            }
            else
            {
                checkResult.Text = "WRONG, try again";
                checkResult.TextColor = Color.Red;
            }
        }
    }
}