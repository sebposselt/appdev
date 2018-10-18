using System;
using LFG.viewmodels;

namespace LFG.models
{
    public class Profile : ViewModelBase
    {
        public string Username { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Age { get; set; }
        public string ProfileText { get; set; }
        public string SteamTag { get; set; }
        public string XboxLiveTag { get; set; }
        public string DiscordTag { get; set; }
        public string PSNTag { get; set; }

        private Game game1;
        public Game Game1 { get { return game1; } set { game1 = value; OnPropertyChanged(); } }
        public Game Game2 { get; set; }
        public Game Game3 { get; set; }
        public Game Game4 { get; set; }
        public Game Game5 { get; set; }

        public Profile()
        {
            //default values
            Region = "None";
            Language = "None";
            Age = "None";
            ProfileText = "e.g. Hi my name Phillip J. Fry!";

            Game1 = new Game();
            Game2 = new Game();
            Game3 = new Game();
            Game4 = new Game();
            Game5 = new Game();
        }
    }
}
