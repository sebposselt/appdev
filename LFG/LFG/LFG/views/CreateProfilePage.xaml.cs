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

        void Region_Tapped(object sender, System.EventArgs e)
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

        void Language_Tapped(object sender, System.EventArgs e)
        {
            var page = new LanguagePage();
            //string selectedRegion = page.RegionList.SelectedItem.ToString();
            page.LanguageList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                language.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }

        void Age_Tapped(object sender, System.EventArgs e)
        {
            var page = new AgePage();
            //string selectedRegion = page.RegionList.SelectedItem.ToString();
            page.AgeList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                age.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }


        //maybe issue with the platform1 tag. I want to reuse this eventhandler, so i need to ensure it can write to different labels in the xaml
        void Platform_Tapped(object sender, System.EventArgs e)
        {
            var page = new PlatformPage();
            //string selectedRegion = page.RegionList.SelectedItem.ToString();
            page.PlatformList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                platform1.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }

        void Skill_Tapped(object sender, System.EventArgs e)
        {
            var page = new SkillPage();
            //string selectedRegion = page.RegionList.SelectedItem.ToString();
            page.SkillList.ItemSelected += (object src, SelectedItemChangedEventArgs args) =>
            {
                skill1.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }
    }
}


