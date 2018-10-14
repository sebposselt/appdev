using System;
using System.Collections.Generic;
using System.Diagnostics;
using LFG.viewmodels;
using Xamarin.Forms;

namespace LFG.views
{
    public partial class MainPage : TabbedPage
    {
        private MainPageViewModel _mainPageViewModel;

        public MainPage()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            _mainPageViewModel = new MainPageViewModel();
            BindingContext = _mainPageViewModel;
            InitializeComponent();
        }
    }
}
