using System;
using System.Collections.Generic;
using LFG.models;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class YesNoPage : ContentPage
    {
        public YesNoPage(Profile profile)
        {

            var tmp = new ProfileView(profile);
            InitializeComponent();
            profilePlaceHolder.Children.Add(tmp);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("yes clicked");
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Console.WriteLine("no clicked");
        }
    }
}
