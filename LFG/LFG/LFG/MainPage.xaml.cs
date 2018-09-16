using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LFG
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void Profile_Button_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Profile());
        }

        private async void Matchmaking_Button_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Matchmaking());
        }
    }
}
