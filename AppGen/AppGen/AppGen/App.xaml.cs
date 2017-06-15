using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGen.Generator;
using Xamarin.Forms;

namespace AppGen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
        }

        protected override void OnStart()
        {

            AppGenerator appgen = App.Current.Resources["AppGenerator"] as AppGenerator;
            appgen.GenerateFromConfig();
            MainPage = new NavigationPage();

            ContentPage cp = new ContentPage();
            cp.Content = appgen.MainPage;
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
