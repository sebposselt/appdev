﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LFG.viewmodels;
using LFG.views.profileViews;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class CreateProfilePage : ContentPage
    {
        private CreateProfilePageViewModel _createProfilePageViewModel;

        public CreateProfilePage()
        {
            _createProfilePageViewModel = new CreateProfilePageViewModel();
            BindingContext = _createProfilePageViewModel;
            InitializeComponent();
        }



        void Region_Tapped(object sender, System.EventArgs e)
        {
            var page = new profileViews.RegionPage();
            page.RegionList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                region.Text = args.SelectedItem.ToString();
                // is this okay according to MVVM?? I don't know
                _createProfilePageViewModel.PlayerProfile.Region = args.SelectedItem.ToString();
                Debug.WriteLine(_createProfilePageViewModel.PlayerProfile.Region);
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }

        void Language_Tapped(object sender, System.EventArgs e)
        {
            var page = new profileViews.LanguagePage();
            page.LanguageList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                language.Text = args.SelectedItem.ToString();
                _createProfilePageViewModel.PlayerProfile.Language = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }

        void Age_Tapped(object sender, System.EventArgs e)
        {
            var page = new profileViews.AgePage();
            page.AgeList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                age.Text = args.SelectedItem.ToString();
                _createProfilePageViewModel.PlayerProfile.Age = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }


        //maybe issue with the platform1 tag. I want to reuse this eventhandler, so i need to ensure it can write to different labels in the xaml
        //void Platform_Tapped(object sender, System.EventArgs e)
        //{
        //    var page = new profileViews.PlatformPage();
        //    page.PlatformList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
        //    {
        //        platform1.Text = args.SelectedItem.ToString();
        //        _createProfilePageViewModel.PlayerProfile.Game1.Platform = args.SelectedItem.ToString();
        //        Navigation.PopAsync();
        //    };
        //    Navigation.PushAsync(page);
        //}

        //void Skill_Tapped(object sender, System.EventArgs e)
        //{
        //    var page = new profileViews.SkillPage();
        //    page.SkillList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
        //    {
        //        skill1.Text = args.SelectedItem.ToString();
        //        _createProfilePageViewModel.PlayerProfile.Game1.SkillLevel = args.SelectedItem.ToString();
        //        Navigation.PopAsync();
        //    };
        //    Navigation.PushAsync(page);
        //}

        void SavedProfile_Clicked(object sender, System.EventArgs e)
        {
            //Move to VM!!!
            //_createProfilePageViewModel.PlayerProfile.Username = username.Text.ToString();
            //_createProfilePageViewModel.PlayerProfile.Region = region.Text;
            //_createProfilePageViewModel.PlayerProfile.Language = language.Text;
            //_createProfilePageViewModel.PlayerProfile.Age = age.Text;
            //_createProfilePageViewModel.PlayerProfile.ProfileText = profiletext.Text;
            //_createProfilePageViewModel.PlayerProfile.SteamTag = steamtag.Text;
            //_createProfilePageViewModel.PlayerProfile.XboxLiveTag = xboxtag.Text;
            //_createProfilePageViewModel.PlayerProfile.DiscordTag = discordtag.Text;
            //_createProfilePageViewModel.PlayerProfile.PSNTag = psntag.Text;

            //to ensure all of the app is using an updated player profile.
            var app = Application.Current as App;
            app.User = _createProfilePageViewModel.PlayerProfile;

            Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);
        }
    }
}


