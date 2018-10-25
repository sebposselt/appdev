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
        private bool isID = false;
        private bool isMe = false;
        private NavigationManager navManager;
        private Dictionary<string, string> _searchFilter;

        public LFGFilterPageViewModel()
        {
            navManager = NavigationManager.Instance;

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
            PullFromDB();
            PushToDB();

            navManager.SwitchPage(new MatchMakingPage());
            IsBusy = false;
        }
    
    
        private void PushToDB()
        {
            //opens connection TO azure DB
            SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            var app = App.Current as App;

            app.GameSerialization();

            //Save data to DB
            string push = "Insert into [LFGdb](Username, Region, Language, Age, ProfileText, SteamTag, DiscordTag, XboxLiveTag, PSNTag, Game1, Game2, Game3, Game4, Game5) " +
                "Values ('" + app.User.Username + "', '" + app.User.Region + "', '" + app.User.Language + "', '" + app.User.Age + "', '" + app.User.ProfileText + "', " +
                "'" + app.User.SteamTag + "', '" + app.User.DiscordTag + "', '" + app.User.XboxLiveTag + "', '" + app.User.PSNTag + "', '" + app.Game1 + "', '" + app.Game2 + "'," +
                " '" + app.Game3 + "', '" + app.Game4 + "', '" + app.Game5 + "')";

            SqlCommand save = new SqlCommand(push, DB);
            DB.Open();
            save.ExecuteNonQuery();
            DB.Close();
        }

        private void PullFromDB()
        {

            //opens connection TO azure DB
            SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            var app = App.Current as App;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM LFGdb";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DB;

            DB.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            if (reader.HasRows) {
                while (reader.Read()) {
                    Profile tmp = new Profile();
                    for (int i = 0; i < reader.FieldCount; i++) {
                        string propertyName = reader.GetName(i);
                        string data = reader.GetValue(i).ToString();
                        //skips saving ID value
                        if (propertyName.StartsWith("ID")) {
                            isID = true;
                        }
                        else {
                            isID = false;
                        }

                        //checks if your username is the same as the one you matched
                        if (propertyName.StartsWith("User")) {
                            if(data == app.User.Username) {
                                isMe = true;
                            } else {
                                isMe = false;
                            }
                        }

                        //saves the game object type
                        if (propertyName.StartsWith("Game")) {
                            Game tmpGame = new Game();
                            tmpGame = JsonConvert.DeserializeObject<Game>(data);
                            tmp[propertyName] = tmpGame;
                        }
                        else {
                            if (!isID) {
                                tmp[propertyName] = data;
                            }
                        }
                    }
                    if (!isMe) {
                        app.PotentialMathces.Add(tmp);
                    }
                }
            }
            else {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            DB.Close();
        }

    }
}
