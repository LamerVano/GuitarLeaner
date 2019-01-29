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
	public partial class PractisePage : ContentPage
	{
        public List<string> Accords { get; set; }
        public List<string> Chosen { get; set; }

        public PractisePage()
        {
            InitializeComponent();
            Accords = new List<string> { "Am", "Dm", "D", "Em", "C", "G" };
            Chosen = new List<string> { };
            accordList.ItemsSource = Accords;

        }
        public void StartPlay(object some, EventArgs e)
        {

        }
        public void accordList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                if (Chosen.Contains(e.SelectedItem.ToString())) { }
                else
                {
                    Chosen.Add(e.SelectedItem.ToString());
                    string all = "";
                    foreach (string item in Chosen)
                    {
                        all += item + " ";
                    }
                    selected.Text = all;
                }
            }
        }
        private async void ToHearingPage(object sender, EventArgs e)
        {
            if (Chosen.Count != 0)
            {
                Stack<string> gameStack = new Stack<string>();
                Chosen.Reverse();
                foreach (string item in Chosen)
                {
                    gameStack.Push(item);
                }
                await Navigation.PushAsync(new Hearing(gameStack));
            }
            else
            {
                changeColor.TextColor = Color.Red;
                DependencyService.Get<IAudio>().PlayAudioFile("miss.mp3");
            }
        }
        private async void ToLearningPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LearningPage());
        }
        private async void ToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void ToMemoryGame(object sender, EventArgs e)
        {
            if (Chosen.Count != 0)
            {
                Stack<string> gameStack = new Stack<string>();
                Chosen.Reverse();
                foreach (string item in Chosen)
                {
                    gameStack.Push(item);
                }
                await Navigation.PushAsync(new MemoryGame(gameStack));
            }
            else
            {
                changeColor.TextColor = Color.Red;
                DependencyService.Get<IAudio>().PlayAudioFile("miss.mp3");
            }
        }
        private async void ToOnTimeGame(object sender, EventArgs e)
        {
            if (Chosen.Count != 0)
            {
                Stack<string> gameStack = new Stack<string>();
                Chosen.Reverse();
                foreach (string item in Chosen)
                {
                    gameStack.Push(item);
                }
                await Navigation.PushAsync(new OnTimeGame(gameStack));
            }
            else
            {
                changeColor.TextColor = Color.Red;
                DependencyService.Get<IAudio>().PlayAudioFile("miss.mp3");
            }
        }
    }
}