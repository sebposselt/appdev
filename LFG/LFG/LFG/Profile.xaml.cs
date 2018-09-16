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
    }
}