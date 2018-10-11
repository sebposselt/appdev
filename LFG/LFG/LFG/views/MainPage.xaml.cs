using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class MainPage : TabbedPage
    {

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreateProfilePage());
            Navigation.RemovePage(this);
            Debug.WriteLine("Settings clicked!");
        }

        public MainPage()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

        }
    }
}
