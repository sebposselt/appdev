using System;
using System.Collections.Generic;
using LFG.viewmodels;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class MatchMakingPage : CarouselPage
    {
        private MatchMakingPageViewModel  _matchMakingPageViewModel;
        public List<ContentPage> PotentialMatches;

        public MatchMakingPage()
        {
            PotentialMatches = new List<ContentPage>();
            FillList();
            _matchMakingPageViewModel = new MatchMakingPageViewModel();
            BindingContext = _matchMakingPageViewModel;

            InitializeComponent();
        }


        private void FillList()
        {
            var app = App.Current as App;
            int len = app.PotentialMathces.Count;
            for (int i = 0; i < len; i++)
            {
                var profile = app.PotentialMathces[i];

                //var page = new DisplayProfilePage(profile);
                var page = new YesNoPage(profile);
                Children.Add(page);
                PotentialMatches.Add(page); //not sure if needed.
            }
        }
                

    }
}
