using System;
using System.Collections.Generic;
using LFG.tools;
using LFG.viewmodels;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class MatchMakingPage : CarouselPage
    {
        private MatchMakingPageViewModel _matchMakingPageViewModel;
        public List<ContentPage> PotentialMatches;
        private NavigationManager navManager;

        public MatchMakingPage()
        {
            navManager = NavigationManager.Instance;
            PotentialMatches = new List<ContentPage>();
            FillList();
            //_matchMakingPageViewModel = new MatchMakingPageViewModel();
            //BindingContext = _matchMakingPageViewModel;

            InitializeComponent();
        }


        private void FillList()
        {
            var app = App.Current as App;
            int len = app.PotentialMathces.Count;
            for (int i = 0; i < len; i++)
            {
                var profile = app.PotentialMathces[i];
                var page = new YesNoPage(profile);
                Children.Add(page);
                
            }
        }

        public void RemoveAndGoToNext()
        {
            var carouselPage = this;
            var pageCount = carouselPage.Children.Count;

            //Check if there is 1 or 0 matches left.
            if (pageCount < 2)
            {
                NavigationManager.Instance.SwitchPage(new MainPage());
                carouselPage.Children.Clear();
                return;
            }

            var index = carouselPage.Children.IndexOf(carouselPage.CurrentPage);
            var nextPageIndex = index;
            if (nextPageIndex >= pageCount)
            { 
                nextPageIndex = 0; 
            }
            carouselPage.CurrentPage = carouselPage.Children[nextPageIndex];
            carouselPage.Children.RemoveAt(index);
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


    }
}
