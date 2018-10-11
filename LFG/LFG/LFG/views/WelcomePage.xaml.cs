﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LFG.views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new CreateProfilePage());
            Navigation.RemovePage(this);
        }
    }

    
}