using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ListaDeComprasXamarin.View;

namespace ListaDeComprasXamarin
{
    public class App : Application
    {
        private MainPage _mainPage;

        public App()
        {

            _mainPage = new ListaDeComprasXamarin.View.MainPage();
            MainPage = new NavigationPage(_mainPage);
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
