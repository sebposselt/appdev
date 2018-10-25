using System;
namespace LFG.models
{
    public class Game
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public string SkillLevel { get; set; }


        public Game()
        {

        }


        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

    }
}
