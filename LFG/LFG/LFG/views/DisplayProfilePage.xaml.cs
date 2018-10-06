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
        private Profile _user;

        public DisplayProfilePage()
        {


            _user = new Profile();
            dummyprofile();
            _displayProfilePageViewModel = new DisplayProfilePageViewModel(_user);
            BindingContext = _displayProfilePageViewModel;
            InitializeComponent();
            //NavigationPage.HasNavigationBar = "false"

        }

        private void dummyprofile()
        {
            _user.Username = "Fry";
            _user.Region = "Europe";
            _user.Language = "English";
            _user.Age = "46-55";
            _user.ProfileText = "My name is Phillip J. Fry, and I come from the year 2000";
            _user.SteamTag = "FrenchFry";
            _user.DiscordTag = "FrenchFry#5556";
            _user.XboxLiveTag = "FrenchFry";
            _user.PSNTag = "FrenchFry";

            _user.Game1.Title = "CSGO1";
            _user.Game1.Platform = "PC";
            _user.Game1.SkillLevel = "Experinced";

            _user.Game2.Title = "CSGO2";
            _user.Game2.Platform = "PC";
            _user.Game2.SkillLevel = "Experinced";

            _user.Game3.Title = "CSGO3";
            _user.Game3.Platform = "PC";
            _user.Game3.SkillLevel = "Experinced";

            _user.Game4.Title = "CSGO4";
            _user.Game4.Platform = "PC";
            _user.Game4.SkillLevel = "Experinced";

            _user.Game5.Title = "CSGO5";
            _user.Game5.Platform = "PC";
            _user.Game5.SkillLevel = "Experinced";
        }
    }
}
