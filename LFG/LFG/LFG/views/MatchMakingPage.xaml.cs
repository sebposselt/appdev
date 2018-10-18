using System;
using System.Collections.Generic;
using LFG.viewmodels;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class MatchMakingPage : ContentPage
    {
        private MatchMakingPageViewModel  _matchMakingPageViewModel;

        public MatchMakingPage()
        {
            _matchMakingPageViewModel = new MatchMakingPageViewModel();
            BindingContext = _matchMakingPageViewModel;
            InitializeComponent();
        }
    }
}
