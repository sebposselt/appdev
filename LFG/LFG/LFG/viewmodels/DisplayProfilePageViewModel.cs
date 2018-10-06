using System;
using LFG.models;

namespace LFG.viewmodels
{
    public class DisplayProfilePageViewModel : ViewModelBase
    {
        public Profile PlayerProfile;

        public DisplayProfilePageViewModel(Profile profile)
        {
            
            PlayerProfile = profile;
        }





    }
}
