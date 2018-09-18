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
	public partial class Matchmaking : ContentPage
	{
		public Matchmaking ()
		{
			InitializeComponent ();
		}

        private async void MainMenu_Button_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Profile_Button_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}