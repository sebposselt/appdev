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
    }
}
