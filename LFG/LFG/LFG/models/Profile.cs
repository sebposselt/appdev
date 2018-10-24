using System;
using LFG.viewmodels;
using System.Runtime.Serialization;

namespace LFG.models
{
    [DataContract]
    public class Profile
    {
        [DataMember] public string Username { get; set; }
        [DataMember] public string Region { get; set; }
        [DataMember] public string Language { get; set; }
        [DataMember] public string Age { get; set; }
        [DataMember] public string ProfileText { get; set; }
        [DataMember] public string SteamTag { get; set; }
        [DataMember] public string XboxLiveTag { get; set; }
        [DataMember] public string DiscordTag { get; set; }
        [DataMember] public string PSNTag { get; set; }


        [DataMember] public Game Game1 { get; set; }
        [DataMember] public Game Game2 { get; set; }
        [DataMember] public Game Game3 { get; set; }
        [DataMember] public Game Game4 { get; set; }
        [DataMember] public Game Game5 { get; set; }

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
