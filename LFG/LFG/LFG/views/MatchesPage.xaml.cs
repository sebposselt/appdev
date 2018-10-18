using System;
using System.Collections.Generic;
using LFG.viewmodels;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class MatchesPage : ContentPage
    {
        private MatchesPageViewModel _matchesPageViewModel;
        public MatchesPage()
        {
            _matchesPageViewModel = new MatchesPageViewModel();
            BindingContext = _matchesPageViewModel;
            InitializeComponent();
        }
    }
}
