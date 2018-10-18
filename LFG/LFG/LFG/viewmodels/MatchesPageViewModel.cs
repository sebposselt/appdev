using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LFG.models;
using Xamarin.Forms;

namespace LFG.viewmodels
{
    public class MatchesPageViewModel : ViewModelBase
    {
        private ObservableCollection<Profile> _matches;
        private Profile _selectedProfile;

        public MatchesPageViewModel()
        {
            var app = App.Current as App;
            List<Profile> tmp = app.Mathces;
            _matches = new ObservableCollection<Profile>(tmp);
            DeleteCommand = new Command(() => Delete());
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
                OnPropertyChanged();
            }
        }

        private void Delete()
        {
            if (SelectedProfile != null)
            {
                Mathces.Remove(SelectedProfile);

            }
        }

    }
}