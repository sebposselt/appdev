using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using LFG.models;
using LFG.tools;
using LFG.views;
using Xamarin.Forms;

namespace LFG.viewmodels
{
    public class CreateProfilePageViewModel : ViewModelBase
    {
        private NavigationManager navManager;
        public Profile PlayerProfile { get; set; }
        public ICommand SaveCommand { get; private set; }
        private List<string> _skillList = new List<string>
        {
            "Beginner",
            "Intermediate",
            "Experinced",
            "Pro"
        };
        private List<string> _platformList = new List<String>
        {
                "PC",
                "Xbox",
                "PlayStation",
                "Nintendo"
        };


        public CreateProfilePageViewModel()
        {
            navManager = NavigationManager.Instance;
            var app = Application.Current as App;
            PlayerProfile = app.User;
            SaveCommand = new Command(() => Save());
        }

        public List<string> SkillList { get { return _skillList; } }
        public List<string> PlatformList { get { return _platformList; } }
        // example og using ViewModel
        //private string name { get; set; }
        //public string Name
        //{
        //    get { return name; }
        //    set 
        //    {
        //        if (name != value)
        //        {
        //            name = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}


        //TODO function to save PlayerProfile
        public void Save()
        {
            var app = Application.Current as App;
            app.User = PlayerProfile;
            navManager.SwitchPagePopCurrent(new MainPage());
            Console.WriteLine("Saved!");
        }
    }
}
