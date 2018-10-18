using System;
using Xamarin.Forms;

namespace LFG.tools
{
    public class NavigationManager
    {
        private static NavigationManager instance;
        private INavigation navigation;

        private NavigationManager() { }

        public static NavigationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NavigationManager();
                }
                return instance;
            }
        }

        public Page _currPage
        {
            get
            {
                int index = navigation.NavigationStack.Count - 1;
                return navigation.NavigationStack[index];
            }
        }

        public INavigation Navigation
        {
            set { navigation = value; }
        }



        // Methods for page switching
        public void SwitchPagePopCurrent(Page page)
        {
            var currPage = _currPage;
            navigation.PushAsync(page);
            navigation.RemovePage(currPage);
        }

        public void SwitchPage(Page page)
        {
            navigation.PushAsync(page);
        }

    }

}
