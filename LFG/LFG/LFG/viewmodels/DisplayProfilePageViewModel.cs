using System;
using LFG.models;
using LFG.views;

namespace LFG.viewmodels
{
    public class DisplayProfilePageViewModel : ViewModelBase
    {
        public Profile PlayerProfile { get; set;}

        public DisplayProfilePageViewModel(Profile profile)
        {
            
            PlayerProfile = profile;
        }

    }
}
