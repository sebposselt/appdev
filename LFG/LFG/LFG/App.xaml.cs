using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LFG.views;
using LFG.models;
using LFG.tools;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

using System.Reflection;
using Newtonsoft.Json;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LFG
{
    public partial class App : Application
    {
        private Random r = new Random(42); //used for fakeprofile function
        private List<Profile> _matches;
        private List<Profile> _potentialMatches;
        private Profile _user;
        private Dictionary<string, string> _searchFilter;
        private DBMediator _DBMediator;


        public App()
        {
            _matches = new List<Profile>();
            _potentialMatches = new List<Profile>();
            _user = new Profile();
            _searchFilter = new Dictionary<string, string>();
            _DBMediator = new DBMediator();

            //first time opening the app
            //MainPage = new NavigationPage(new WelcomePage());

            //profile already exists

            //         //</dev>
            //for (int i = 0; i < 10; i++)
            //{
            //    _matches.Add(fakeprofile());
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    fakeprofile();
            //}
            dummyprofile();
                     //</dev>

            MainPage = new NavigationPage(new MainPage());
            NavigationManager.Instance.Navigation = MainPage.Navigation;
            InitializeComponent();

        }

        public Profile User 
        { 
            get {return _user; } 
            set {_user = value;}
        }
        public List<Profile> Mathces
        {
            get {return _matches;}
            set {_matches = value;}
        }
        public List<Profile> PotentialMathces
        {
            get {return _potentialMatches;}
            set {_potentialMatches= value;}
        }

        public Dictionary<string,string> SearchFilter
        {
            get { return _searchFilter;}
            set {_searchFilter = value;}
        }

        protected override void OnStart()
        {

            //first time opening the app
            //MainPage = new NavigationPage(new WelcomePage());

            //profile already exists

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
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

        private void fakeprofile()
        {
            var _user = new Profile();
            _user.Username = "Fry"; 
            _user.Region = "Europe";
            _user.Language = "English";
            _user.Age = "46-55";
            _user.ProfileText = "My name is Phillip J. Fry, and I come from the year 2000";
            _user.SteamTag = "FrenchFry1";
            _user.DiscordTag = "FrenchFry#5556";
            _user.XboxLiveTag = "FrenchFry";
            _user.PSNTag = "FrenchFry1";
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

            _user.Username += r.Next(1, 1001);
            _DBMediator.PushToDB_DEV(_user);
        }



        //private void PushToDB()
        //{
        //    //opens connection TO azure DB
        //    SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
        //    var app = App.Current as App;

        //    //Save data to DB
        //    string push = "Insert into [LFGdb](Username, Region, Language, Age, ProfileText, SteamTag, DiscordTag, XboxLiveTag, PSNTag, Game1, Game2, Game3, Game4, Game5) " +
        //        "Values ('" + app.User.Username + "', '" + app.User.Region + "', '" + app.User.Language + "', '" + app.User.Age + "', '" + app.User.ProfileText + "', " +
        //        "'" + app.User.SteamTag + "', '" + app.User.DiscordTag + "', '" + app.User.XboxLiveTag + "', '" + app.User.PSNTag + "', '" + app.User.Game1.Title + "', '" + app.User.Game2.Title + "'," +
        //        " '" + app.User.Game3.Title + "', '" + app.User.Game4.Title + "', '" + app.User.Game5.Title + "')";

        //    SqlCommand save = new SqlCommand(push, DB);
        //    DB.Open();
        //    save.ExecuteNonQuery();
        //    DB.Close();
        //}

        //private void PushToDB2(Profile profile)
        //{
        //    User = profile;
        //    //opens connection TO azure DB
        //    SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
        //    var app = App.Current as App;

        //    //serialized Games
        //    GameSerialization();

        //    //Save data to DB
        //    string push = "Insert into [LFGdb](Username, Region, Language, Age, ProfileText, SteamTag, DiscordTag, XboxLiveTag, PSNTag, Game1, Game2, Game3, Game4, Game5) " +
        //        "Values ('" + User.Username + "', '" + User.Region + "', '" + User.Language + "', '" + User.Age + "', '" + User.ProfileText + "', " +
        //        "'" + User.SteamTag + "', '" + User.DiscordTag + "', '" + User.XboxLiveTag + "', '" + User.PSNTag + "', '" + Game1 + "', '" + Game2 + "'," +
        //        " '" + Game3 + "', '" + Game4 + "', '" + Game5 + "')";

        //    SqlCommand save = new SqlCommand(push, DB);
        //    DB.Open();
        //    save.ExecuteNonQuery();
        //    DB.Close();
        //}

        //private void PullFromDB()
        //{

        //    //opens connection TO azure DB
        //    SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataReader reader;

        //    cmd.CommandText = "SELECT * FROM LFGdb";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = DB;

        //    DB.Open();

        //    reader = cmd.ExecuteReader();
        //    // Data is accessible through the DataReader object here.
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            Profile tmp = new Profile();
        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {
        //                string propertyName = reader.GetName(i);
        //                string data = reader.GetValue(i).ToString();
        //                if (propertyName.StartsWith("ID")) {
        //                    isID = true;
        //                } else {
        //                    isID = false;
        //                }

        //                if (propertyName.StartsWith("Game")) {
        //                    Game tmpGame = new Game();
        //                    tmpGame = JsonConvert.DeserializeObject<Game>(data);
        //                    tmp[propertyName] = tmpGame;
        //                }
        //                else {
        //                    if (!isID) {
        //                        tmp[propertyName] = data;
        //                    }
        //                }
        //            }
        //            PotentialMathces.Add(tmp);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No rows found.");
        //    }
        //    reader.Close();
        //    DB.Close();
        //}



    }
}
