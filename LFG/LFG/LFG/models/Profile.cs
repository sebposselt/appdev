using System;
namespace LFG.models
{
    public class Profile
    {
        public string Username;
        public string Region;
        public string Language;
        public string Age;
        public string ProfileText;
        public string SteamTag;
        public string XboxLiveTag;
        public string DiscordTag;
        public string PSNTag;


        public Game Game1;
        public Game Game2;
        public Game Game3;
        public Game Game4;
        public Game Game5;

        public Profile()
        {
            Game1 = new Game();
            Game2 = new Game();
            Game3 = new Game();
            Game4 = new Game();
            Game5 = new Game();
        }
    }
}
