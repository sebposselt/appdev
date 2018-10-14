using System;
using System.Collections.Generic;
using LFG.tools;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class WelcomePage : ContentPage
    {
        private NavigationManager navManager;

        public WelcomePage()
        {
            navManager = NavigationManager.Instance;
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            navManager.SwitchPagePopCurrent(new CreateProfilePage());
        }
    }

    
}