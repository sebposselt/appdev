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
        private Serialization _serializer;
        private NavigationManager navManager;
        private List<SkillLevel> _skillList = new List<SkillLevel>{
            SkillLevel.Beginner,
            SkillLevel.Intermediate,
            SkillLevel.Experinced,
            SkillLevel.Pro
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
            _serializer = new Serialization();
            navManager = NavigationManager.Instance;
            var app = Application.Current as App;
            PlayerProfile = app.User;
            SaveCommand = new Command(() => Save());
        }

        public Profile PlayerProfile { get; set; }
        public ICommand SaveCommand { get; private set; }
        public List<SkillLevel> SkillList { get { return _skillList; } }
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

        public void Save() 
        {
            var app = Application.Current as App;
            app.User = PlayerProfile;
            _serializer.Save(PlayerProfile);

            navManager.SwitchPagePopCurrent(new MainPage());
            Console.WriteLine("Saved!");
        }
    }
}
