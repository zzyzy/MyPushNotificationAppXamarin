using System;
using Newtonsoft.Json;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPushNotificationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            CrossFirebasePushNotification.Current.OnNotificationReceived += (source, args) =>
            {
                Console.WriteLine("Notification received: " + JsonConvert.SerializeObject(args.Data));
            };

            CrossFirebasePushNotification.Current.OnTokenRefresh += (source, args) =>
            {
                Console.WriteLine($"Token refreshed: {args.Token}");
            };
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
