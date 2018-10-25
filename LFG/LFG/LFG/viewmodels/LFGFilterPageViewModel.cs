using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Input;
using LFG.models;
using LFG.tools;
using LFG.views;
using Xamarin.Forms;
namespace LFG.viewmodels
{
    public class LFGFilterPageViewModel : ViewModelBase
    {
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

            navManager.SwitchPage(new MatchMakingPage());
            IsBusy = false;
        }
    
    
        private void PushToDB()
        {
            //opens connection TO azure DB
            SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            var app = App.Current as App;

            //Save data to DB
            string push = "Insert into [LFGdb](Username, Region, Language, Age, ProfileText, SteamTag, DiscordTag, XboxLiveTag, PSNTag, Game1, Game2, Game3, Game4, Game5) " +
                "Values ('" + app.User.Username + "', '" + app.User.Region + "', '" + app.User.Language + "', '" + app.User.Age + "', '" + app.User.ProfileText + "', " +
                "'" + app.User.SteamTag + "', '" + app.User.DiscordTag + "', '" + app.User.XboxLiveTag + "', '" + app.User.PSNTag + "', '" + app.User.Game1.Title + "', '" + app.User.Game2.Title + "'," +
                " '" + app.User.Game3.Title + "', '" + app.User.Game4.Title + "', '" + app.User.Game5.Title + "')";

            SqlCommand save = new SqlCommand(push, DB);
            DB.Open();
            save.ExecuteNonQuery();
            DB.Close();
        }

        private void PullFromDB()
        {

            //opens connection TO azure DB
            SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM LFGdb";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DB;

            DB.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string data = reader.GetValue(i).ToString();
                        Console.WriteLine(data + '\n');
                    }
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            DB.Close();
        }

    }
}
