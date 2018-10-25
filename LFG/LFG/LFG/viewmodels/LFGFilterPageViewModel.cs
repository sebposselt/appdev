using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Input;
using LFG.models;
using LFG.tools;
using LFG.views;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace LFG.viewmodels
{
    public class LFGFilterPageViewModel : ViewModelBase
    {
        private NavigationManager navManager;
        private Dictionary<string, string> _searchFilter;
        private DBMediator _DBMediator;

        public LFGFilterPageViewModel()
        {
            navManager = NavigationManager.Instance;
            _DBMediator = new DBMediator();

            SearchCommand = new Command(Search);
        }

        public ICommand SearchCommand { get; private set; }
        public string Language { get ; set; }
        public string Age { get; set; }
        public string Region { get; set; }



        public Dictionary<string, string> SearchFilter
        {
            get { return _searchFilter; }
            set { _searchFilter = value; }
        }

        private void Search()
        {
            IsBusy = true;
            //create the dict
            _searchFilter = new Dictionary<string, string>();
            _searchFilter.Add("LANGUAGE", Language);
            _searchFilter.Add("AGE", Age);
            _searchFilter.Add("REGION", Region);

            //assigns the dict to app-class
            var app = App.Current as App;
            app.SearchFilter = _searchFilter;

            app.PotentialMathces.Clear();
            _DBMediator.PullFromDB();
            _DBMediator.PushToDB();

            navManager.SwitchPage(new MatchMakingPage());
            IsBusy = false;
        }
    
    



    }
}
