using System;
using System.Windows.Input;
using LFG.tools;
using LFG.views;
using Xamarin.Forms;

namespace LFG.viewmodels
{
    public class MainPageViewModel : ViewModelBase
    {
        private NavigationManager navManager;
        public ICommand SettingsCommand { get; private set; }

        public MainPageViewModel()
        {
            navManager = NavigationManager.Instance;
            SettingsCommand = new Command(() => navManager.SwitchPagePopCurrent(new CreateProfilePage()));
        }
    }
}
