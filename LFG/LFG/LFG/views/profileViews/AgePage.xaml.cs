using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LFG.views/profileViews
{
    public partial class AgePage : ContentPage
    {
        public AgePage()
        {
            InitializeComponent();
            ageList.ItemsSource = new List<string>
            {
                "Below 18",
                "18-25",
                "26-35",
                "36-45",
                "46-55",
                "56-65",
                "65+"
            };
        }

        public ListView AgeList { get { return ageList; } }
    }
}
