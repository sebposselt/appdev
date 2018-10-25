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
                var page = new DisplayProfilePage(profile);
                Children.Add(page);
                PotentialMatches.Add(page);
            }
        }
                

    }
}


//public static void PageRight(this CarouselPage carouselPage)
//{
//    var pageCount = carouselPage.Children.Count;
//    if (pageCount < 2)
//        return;

//    var index = carouselPage.Children.IndexOf(carouselPage.CurrentPage);
//    index++;
//    if (index >= pageCount)
//        index = 0;

//    carouselPage.CurrentPage = carouselPage.Children[index];
//}
