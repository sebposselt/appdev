using System;
using System.Windows.Input;
using LFG.models;
using Xamarin.Forms;

namespace LFG.viewmodels
{
    public class MatchMakingPageViewModel : ViewModelBase
    {

        private Profile _profile;
        private App app;
        public MatchMakingPageViewModel()
        {
            app = Application.Current as App;
            YesCommand = new Command(() => Yes());
            NoCommand = new Command(() => No());
        }

        public ICommand YesCommand { get; private set; }
        public ICommand NoCommand { get; private set; }


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

        public Profile MatchProfile
        {
            get { return _profile; }
            set { _profile = value; }
        }




    }
}

