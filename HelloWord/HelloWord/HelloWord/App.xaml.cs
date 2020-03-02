using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWord
{
    public partial class App : Application
    {
        public static string databaselocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
        }

        public App(string DatabaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            databaselocation = DatabaseLocation;
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
