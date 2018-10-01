using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LFG.views
{
    public partial class RegionPage : ContentPage
    {
        public RegionPage()
        {
            InitializeComponent();
            regionList.ItemsSource = new List<string>
            {
                "North America",
                "South America",
                "Europe",
                "Ociania",
                "Africa",
                "Asia"
            };
        }

        public ListView RegionList { get { return regionList; } }
    }
}

