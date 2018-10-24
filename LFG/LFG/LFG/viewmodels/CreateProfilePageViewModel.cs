using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using LFG.models;
using LFG.tools;
using LFG.views;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace LFG.viewmodels
{
    public class CreateProfilePageViewModel : ViewModelBase
    {
        //opens connection TO azure DB
        SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

        private Serialization _serializer;
        private NavigationManager navManager;
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
            _serializer = new Serialization();
            navManager = NavigationManager.Instance;
            var app = Application.Current as App;
            PlayerProfile = app.User;
            SaveCommand = new Command(() => Save());

            //Save data to DB
            string pull = "Insert into [LFGdb](Username, Region, Language, Age, ProfileText, SteamTag, DiscordTag, XboxLiveTag, PSNTag, Game1, Game2, Game3, Game4, Game5) " +
                "Values ('" + app.User.Username + "', '" + app.User.Region + "', '" + app.User.Language + "', '" + app.User.Age + "', '" + app.User.ProfileText + "', " +
                "'" + app.User.SteamTag + "', '" + app.User.DiscordTag + "', '" + app.User.XboxLiveTag + "', '" + app.User.PSNTag + "', '" + app.User.Game1 + "', '" + app.User.Game2 + "'," +
                " '" + app.User.Game3 + "', '" + app.User.Game4 + "', '" + app.User.Game5 + "')";

            SqlCommand save = new SqlCommand(pull, DB);
            DB.Open();
            save.ExecuteNonQuery();
            DB.Close();
        }
        

        public Profile PlayerProfile { get; set; }
        public ICommand SaveCommand { get; private set; }
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
