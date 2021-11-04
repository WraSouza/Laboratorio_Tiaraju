using Plugin.FirebasePushNotification;
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
            
            MainPage = new View.LoginView();

            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;           
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
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
