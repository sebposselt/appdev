using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LFG.views
{
    public partial class PlatformPage : ContentPage
    {
        public PlatformPage()
        {
            InitializeComponent();
            platformList.ItemsSource = new List<String>
            {
                "PC",
                "Xbox",
                "PlayStation",
                "Nintendo"
            };
        }

        public ListView PlatformList { get { return platformList; } }
    }
}
