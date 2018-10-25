using System;
using System.Collections.Generic;
using LFG.viewmodels;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class LFGFilterPage : ContentPage
    {

        private List<string> _ageList;
        private List<string> _regionList;
        private List<string> _languageList;
        private LFGFilterPageViewModel _LFGFilterPageViewModel;


        public LFGFilterPage()
        {
            _LFGFilterPageViewModel = new LFGFilterPageViewModel();
            InitLists();
            BindingContext = _LFGFilterPageViewModel;
            InitializeComponent();

            age.ItemsSource = AgeList;
            region.ItemsSource = RegionList;
            language.ItemsSource = LanguageList;
        }

        public List<string> AgeList { get { return _ageList; } }
        public List<string> RegionList { get { return _regionList; } }
        public List<string> LanguageList { get { return _languageList; } }


        private void InitLists()
        {
            _ageList = new List<string>
            {
                "Below 18",
                "18-25",
                "26-35",
                "36-45",
                "46-55",
                "56-65",
                "65+"
            };

            _languageList = new List<string>
            {
                "English",
                "Spanish",
                "Italian",
                "French",
                "Portuguese",
                "Chinese",
                "Japanese",
                "Korean",
                "Russian",
                "Other"
            };

            _regionList = new List<string>
            {
                "North America",
                "South America",
                "Europe",
                "Ociania",
                "Africa",
                "Asia"
            };
        }


    }
}
