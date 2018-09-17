using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LFG
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
        public string username;
        public string region;
        public string language;
        public string age;
        public string platform;
        public string game1;
        public string game2;
        public string game3;
        public string game4;
        public string game5;
        public string discord;
        public string steam;
        public string playstation;
        public string xbox;

		public Profile ()
		{
			InitializeComponent ();
		}

        private async void Mainmenu_Clicked_Button(object sender, EventArgs e) {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Matchmaking_Clicked_Button(object sender, EventArgs e) {
            await Navigation.PushAsync(new Matchmaking());
        }

        private void Save_Button_Clicked(object sender, EventArgs e) {
            username = Username.Text;
            region = Region.SelectedItem.ToString();
            language = Language.SelectedItem.ToString();
            age = Age.SelectedItem.ToString();
            platform = Platform.SelectedItem.ToString();
            game1 = Game1.Text;
            game2 = Game2.Text;
            game3 = Game3.Text;
            game4 = Game4.Text;
            game5 = Game5.Text;
            discord = DiscordTag.Text;
            steam = SteamTag.Text;
            playstation = PlaystationTag.Text;
            xbox = XboxTag.Text;
        }
    }
}