using System;
namespace LFG.models
{
    public class Game : viewmodels.ViewModelBase
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        private SkillLevel skillLevel;
        public SkillLevel SkillLevel
        {
            get { return skillLevel; }
            set
            {
                skillLevel = value;
                OnPropertyChanged();
            }
        }
        public string SkillLevelName { get { return SkillLevel.ToString(); } }

        public Game()
        {

        }


    }

    public enum SkillLevel
    {
        Beginner,
        Intermediate,
        Experinced,
        Pro
    }
}
