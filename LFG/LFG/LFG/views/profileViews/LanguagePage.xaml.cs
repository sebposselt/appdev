using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LFG.views
{
    public partial class LanguagePage : ContentPage
    {
        public LanguagePage()
        {
            InitializeComponent();
            languageList.ItemsSource = new List<string>
            {
                "English",
                "Spanish",
                "Italian",
                "French",
                "Portuguese",
                "Chinese",
                "Japanese",
                "Korean",
                "Russian",
                "Other"
            };
        }
        public ListView LanguageList { get { return languageList; } }
    }
}
