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

        public DisplayProfilePage()
        {

            var app = Application.Current as App;
            Profile user = app.User;
            _displayProfilePageViewModel = new DisplayProfilePageViewModel(user);
            BindingContext = _displayProfilePageViewModel;
            InitializeComponent();
        }

        //TO display a specific profile and not the current users' profile
        public DisplayProfilePage(Profile page)
        {
            _displayProfilePageViewModel = new DisplayProfilePageViewModel(page);
            BindingContext = _displayProfilePageViewModel;
            InitializeComponent();
        }



    }
}
