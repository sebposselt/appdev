using System;
using System.Runtime.Serialization;
namespace LFG.models
{
    [DataContract]
    public class Game
    {
        [DataMember] public string Title { get; set; }
        [DataMember] public string Platform { get; set; }
        [DataMember] public string SkillLevel { get; set; }


        public Game()
        {

        }


    }
}
