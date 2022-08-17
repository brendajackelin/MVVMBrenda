using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMBrenda.Views;
using MVVMBrenda.Data;
using System.IO;

namespace MVVMBrenda
{
    public partial class App : Application
    {
        static Database db;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
        public static Database SQLiteBD
        {
            get
            {
                if (db == null)
                {
                    db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "emple.db3"));
                }
                return db;
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
