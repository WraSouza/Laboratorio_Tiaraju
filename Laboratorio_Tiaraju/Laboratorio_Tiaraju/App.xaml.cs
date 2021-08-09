using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new View.AppShell();
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
