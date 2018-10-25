using System;
using System.Data;
using System.Data.SqlClient;
using LFG.models;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace LFG.tools
{
    public class DBMediator
    {

        private bool isID = false;
        private bool isMe = false;
        private string Game1;
        private string Game2;
        private string Game3;
        private string Game4;
        private string Game5;



        public DBMediator()
        {
        }

        private void GameSerialization()
        {
            var app = App.Current as App;

            Game1 = JsonConvert.SerializeObject(app.User.Game1);
            Game2 = JsonConvert.SerializeObject(app.User.Game2);
            Game3 = JsonConvert.SerializeObject(app.User.Game3);
            Game4 = JsonConvert.SerializeObject(app.User.Game4);
            Game5 = JsonConvert.SerializeObject(app.User.Game5);
        }


        public void PushToDB()
        {
            //opens connection TO azure DB
            SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            var app = App.Current as App;

            GameSerialization();

            //Save data to DB
            string push = "Insert into [LFGdb](Username, Region, Language, Age, ProfileText, SteamTag, DiscordTag, XboxLiveTag, PSNTag, Game1, Game2, Game3, Game4, Game5) " +
                "Values ('" + app.User.Username + "', '" + app.User.Region + "', '" + app.User.Language + "', '" + app.User.Age + "', '" + app.User.ProfileText + "', " +
                "'" + app.User.SteamTag + "', '" + app.User.DiscordTag + "', '" + app.User.XboxLiveTag + "', '" + app.User.PSNTag + "', '" + Game1 + "', '" + Game2 + "'," +
                " '" + Game3 + "', '" + Game4 + "', '" + Game5 + "')";

            SqlCommand save = new SqlCommand(push, DB);
            DB.Open();
            save.ExecuteNonQuery();
            DB.Close();
        }


        public void PushToDB_DEV(Profile profile)
        {
            Profile User = profile;
            //opens connection TO azure DB
            SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

            GameSerialization();

            //Save data to DB
            string push = "Insert into [LFGdb](Username, Region, Language, Age, ProfileText, SteamTag, DiscordTag, XboxLiveTag, PSNTag, Game1, Game2, Game3, Game4, Game5) " +
                "Values ('" + User.Username + "', '" + User.Region + "', '" + User.Language + "', '" + User.Age + "', '" + User.ProfileText + "', " +
                "'" + User.SteamTag + "', '" + User.DiscordTag + "', '" + User.XboxLiveTag + "', '" + User.PSNTag + "', '" + Game1 + "', '" + Game2 + "'," +
                " '" + Game3 + "', '" + Game4 + "', '" + Game5 + "')";

            SqlCommand save = new SqlCommand(push, DB);
            DB.Open();
            save.ExecuteNonQuery();
            DB.Close();
        }


        public void PullFromDB()
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
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Profile tmp = new Profile();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string propertyName = reader.GetName(i);
                        string data = reader.GetValue(i).ToString();
                        //skips saving ID value
                        if (propertyName.StartsWith("ID"))
                        {
                            isID = true;
                        }
                        else
                        {
                            isID = false;
                        }

                        //checks if your username is the same as the one you matched
                        if (propertyName.StartsWith("User"))
                        {
                            if (data == app.User.Username)
                            {
                                isMe = true;
                            }
                            else
                            {
                                isMe = false;
                            }
                        }

                        //saves the game object type
                        if (propertyName.StartsWith("Game"))
                        {
                            Game tmpGame = new Game();
                            tmpGame = JsonConvert.DeserializeObject<Game>(data);
                            tmp[propertyName] = tmpGame;
                        }
                        else
                        {
                            if (!isID)
                            {
                                tmp[propertyName] = data;
                            }
                        }
                    }
                    if (!isMe)
                    {
                        app.PotentialMathces.Add(tmp);
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
