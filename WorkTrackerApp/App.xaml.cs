using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorkTrackerApp.Services;
using WorkTrackerApp.Views;
using WorkTrackerApp.Helpers;
using System.IO;

namespace WorkTrackerApp
{
    public partial class App : Application
    {
        static RaportsLocalDatabase database;

        public static RaportsLocalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RaportsLocalDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RaportsSQLite.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            database = Database;
            
            DependencyService.Register<SQLiteDataStore>();
            MainPage = new AppShell();
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
