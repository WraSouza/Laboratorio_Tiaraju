using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Util;
using Android.Widget;
using Plugin.FirebasePushNotification;


namespace Laboratorio_Tiaraju.Droid
{
    [Activity(Label = "Laboratorio_Tiaraju", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            //ParseClient.Initialize(new ParseClient.Configuration
            //{
            //    ApplicationId = GetString(Resource.String.back4app_app_id),
            //    WindowsKey = GetString(Resource.String.back4app_dotnet_key),
            //    Server = "https://parseapi.back4app.com"
            //});
            //FirebasePushNotificationManager.ProcessIntent(this, Intent);
            LoadApplication(new App());

            FirebasePushNotificationManager.ProcessIntent(this, Intent);
            //ParseInstallation.CurrentInstallation.SaveAsync();


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}