using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EGA_Lijst
{
    public partial class App : Application
    {
        static WeeklijstDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
        }
        public static WeeklijstDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WeeklijstDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
