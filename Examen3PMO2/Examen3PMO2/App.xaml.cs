using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen3PMO2
{
    public partial class App : Application
    {
        public static string UbicacionDB = string.Empty;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
     
        public App(string dblocal)
        {

            InitializeComponent();
            UbicacionDB = dblocal;
            MainPage = new NavigationPage(new MainPage());

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
