using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LFG.views
{
    public partial class CreateProfilePage : ContentPage
    {
        public CreateProfilePage()
        {
            InitializeComponent();
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var page = new RegionPage();
            //string selectedRegion = page.RegionList.SelectedItem.ToString();
            page.RegionList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                region.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }
    }
}


