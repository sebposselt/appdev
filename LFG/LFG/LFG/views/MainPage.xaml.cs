using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class MainPage : TabbedPage
    {

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine("clicked"); 
        }

        public MainPage()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

        }
    }
}
