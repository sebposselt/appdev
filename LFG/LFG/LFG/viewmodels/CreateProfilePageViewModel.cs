using System;
using System.Windows.Input;
using LFG.models;
using Xamarin.Forms;

namespace LFG.viewmodels
{
    public class CreateProfilePageViewModel : ViewModelBase
    {

        public Profile PlayerProfile;
        public ICommand SaveCommand { get; private set; }

        public CreateProfilePageViewModel()
        {
            SaveCommand = new Command(Save);
        }


        //TODO function to save PlayerProfile
        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
