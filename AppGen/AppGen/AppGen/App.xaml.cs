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
            AppGenerator appgen = App.Current.Resources["AppGenerator"] as AppGenerator;
            appgen.GenerateFromConfig();
            MainPage = appgen.MainPage;
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
