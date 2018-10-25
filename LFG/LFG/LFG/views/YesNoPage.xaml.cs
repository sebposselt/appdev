using System;
using System.Collections.Generic;
using LFG.models;
using Xamarin.Forms;
using LFG.viewmodels;

namespace LFG.views
{
    public partial class YesNoPage : ContentPage
    {
        private MatchMakingPageViewModel _matchMakingPageViewModel;
        private Profile _profile;


        public YesNoPage(Profile profile)
        {
            _profile = profile;
            _matchMakingPageViewModel = new MatchMakingPageViewModel();
            _matchMakingPageViewModel.MatchProfile = profile;
            BindingContext = _matchMakingPageViewModel;
            var tmp = new ProfileView(profile);
            InitializeComponent();
            profilePlaceHolder.Children.Add(tmp);
        }


        public Profile MatchProfile
        {
            get { return _profile; }
            private set { _profile = value; }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var tmp = this.Parent as MatchMakingPage;
            tmp.RemoveAndGoToNext();
        }
    }
}
