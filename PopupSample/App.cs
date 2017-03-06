using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PopupSample.Pages;
using Xamarin.Forms;

namespace PopupSample
{
    public class App : Application
    {
        public App()
        {
            var contentPage = new HomePage();
            MainPage = new NavigationPage(contentPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
