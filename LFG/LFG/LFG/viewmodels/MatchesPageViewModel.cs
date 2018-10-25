using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LFG.models;
using LFG.tools;
using LFG.views;
using Xamarin.Forms;

namespace LFG.viewmodels
{
    public class MatchesPageViewModel : ViewModelBase
    {
        private NavigationManager navManager;
        private ObservableCollection<Profile> _matches;
        private Profile _selectedProfile;

        public MatchesPageViewModel()
        {
            navManager = NavigationManager.Instance;
            var app = App.Current as App;
            _matches = app.Mathces;
            DeleteCommand = new Command<Profile>((Profile obj) => Delete(obj));
        }

        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<Profile> Mathces
        {
            get
            {
                return _matches;
            }
            set
            {
                _matches = value;
                OnPropertyChanged();
            }
        }

        public Profile SelectedProfile
        {
            get { return _selectedProfile; }
            set 
            {
                _selectedProfile = value;
                navManager.SwitchPage(new DisplayProfilePage(_selectedProfile));
                //TODO fix so when you go back from the directed page, _selecteditem = null
                OnPropertyChanged();
            }
        }

        private void Delete(Profile profile)
        {
            if (profile != null)
            {
                Mathces.Remove(profile);
            }
        }

    }
}