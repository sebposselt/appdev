using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LFG.views.profileViews
{
    public partial class SkillPage : ContentPage
    {
        public SkillPage()
        {
            InitializeComponent();
            skillList.ItemsSource = new List<string>
            {
                "Beginner",
                "Intermediate",
                "Experinced",
                "Pro"
            };
        }

        public ListView SkillList { get { return skillList; } }
    }
}
