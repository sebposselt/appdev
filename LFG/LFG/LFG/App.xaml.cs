using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LFG.views;
using LFG.models;
using LFG.tools;
using System.Collections.Generic;
using PCLStorage;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LFG
{
    public partial class App : Application
    {
        private Random r = new Random(42); //used for fakeprofile function
        public Profile PlayerProfile { get; set; }
        private Serialization _serializer;
        private NavigationManager navManager;

        private List<Profile> _matches;
        private Profile _user;


        public App()
        {
            _matches = new List<Profile>();
            _user = new Profile();

            //first time opening the app
            //MainPage = new NavigationPage(new WelcomePage());

            //profile already exists

            //         //<dev>
            for (int i = 0; i < 11; i++)
            {
                _matches.Add(fakeprofile());
            }
            dummyprofile();
            //         //</dev>

            MainPage = new NavigationPage(new MainPage());

            NavigationManager.Instance.Navigation = MainPage.Navigation;
            InitializeComponent();
        }

        public Profile User 
        { 
            get 
            { 
                return _user; 
            } 
            set {
                _user = value;
            }
        }
        public List<Profile> Mathces
        {
            get
            {
                return _matches;
            }
            set
            {
                _matches = value;
            }
        }

        protected override void OnStart()
        {

            //first time opening the app
            //MainPage = new NavigationPage(new WelcomePage());

            //profile already exists
            //User = PlayerProfile;
            _serializer = new Serialization();
            navManager = NavigationManager.Instance;

            try {
                _serializer.Load(User);
            }
            catch (NullReferenceException e) {
                if (e.Data == null) {
                    _serializer.Load(PlayerProfile);
                    navManager.SwitchPage(new DisplayProfilePage());
                }
                else {
                    //navManager.SwitchPage(new WelcomePage());
                }
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            _serializer = new Serialization();
            _serializer.Save(User);

        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            _serializer = new Serialization();
            navManager = NavigationManager.Instance;

            _serializer.Load(PlayerProfile);
            navManager.SwitchPagePopCurrent(new DisplayProfilePage());

        }

        /// <summary>
        /// Dummyprofile is a function for development purposes.
        /// </summary>
        private void dummyprofile()
        {
            _user.Username = "Fry";
            _user.Region = "Europe";
            _user.Language = "English";
            _user.Age = "46-55";
            _user.ProfileText = "My name is Phillip J. Fry, and I come from the year 2000";
            _user.SteamTag = "FrenchFry";
            _user.DiscordTag = "FrenchFry#5556";
            _user.XboxLiveTag = "FrenchFry";
            _user.PSNTag = "FrenchFry";

            _user.Game1.Title = "CSGO1";
            _user.Game1.Platform = "PC";
            _user.Game1.SkillLevel = "Experinced";

            _user.Game2.Title = "CSGO2";
            _user.Game2.Platform = "PC";
            _user.Game2.SkillLevel = "Experinced";

            _user.Game3.Title = "CSGO3";
            _user.Game3.Platform = "PC";
            _user.Game3.SkillLevel = "Experinced";

            _user.Game4.Title = "CSGO4";
            _user.Game4.Platform = "PC";
            _user.Game4.SkillLevel = "Experinced";

            _user.Game5.Title = "CSGO5";
            _user.Game5.Platform = "PC";
            _user.Game5.SkillLevel = "Experinced";
        }

        private Profile fakeprofile()
        {
            var _user = new Profile();
            _user.Username = "FryASÆDJKASFJÆJKL";
            _user.Region = "Europe";
            _user.Language = "English";
            _user.Age = "46-55";
            _user.ProfileText = "My name is Phillip J. Fry, and I come from the year 2000";
            _user.SteamTag = "FrenchFry";
            _user.DiscordTag = "FrenchFry#5556";
            _user.XboxLiveTag = "FrenchFry";
            _user.PSNTag = "FrenchFry";
            _user.Game1.Title = "CSGO1";
            _user.Game1.Platform = "PC";
            _user.Game1.SkillLevel = "Experinced";
            _user.Game2.Title = "CSGO2";
            _user.Game2.Platform = "PC";
            _user.Game2.SkillLevel = "Experinced";
            _user.Game3.Title = "CSGO3";
            _user.Game3.Platform = "PC";
            _user.Game3.SkillLevel = "Experinced";
            _user.Game4.Title = "CSGO4";
            _user.Game4.Platform = "PC";
            _user.Game4.SkillLevel = "Experinced";
            _user.Game5.Title = "CSGO5";
            _user.Game5.Platform = "PC";
            _user.Game5.SkillLevel = "Experinced";

            _user.Username += r.Next(1, 101);
            return _user;
        }




    }
}
