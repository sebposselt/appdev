using System;
using System.Windows.Input;
using LFG.models;
using LFG.tools;
using Xamarin.Forms;
using System.Linq;
using LFG.views;

namespace LFG.viewmodels
{
    public class MatchMakingPageViewModel : ViewModelBase
    {
        private Profile _profile;
        private App app;
        private NavigationManager navManager;



        public MatchMakingPageViewModel()
        {
            app = Application.Current as App;
            navManager = NavigationManager.Instance;
            YesCommand = new Command(() => Yes());
            NoCommand = new Command(() => No());
        }


        public ICommand YesCommand { get; private set; }
        public ICommand NoCommand { get; private set; }
        public Profile MatchProfile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        private void No()
        {
            app.PotentialMathces.Remove(MatchProfile);
            // to to next carouselpage
        }

        private void Yes()
        {
            app.Mathces.Add(MatchProfile);
            // to to next carouselpage
        }
    }
}

