using System;
using System.Collections.Generic;
using LFG.models;
using LFG.viewmodels;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class DisplayProfilePage : ContentPage
    {
        private DisplayProfilePageViewModel _displayProfilePageViewModel;

        public DisplayProfilePage(Profile profile)
        {
            _displayProfilePageViewModel = new DisplayProfilePageViewModel(profile);
            InitializeComponent();
            //NavigationPage.HasNavigationBar = "false"

        }




    }
}
