using System;

using Android.App;
using Android.Runtime;
using Plugin.FirebasePushNotification;

namespace XamarinFCM.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //If debug you should reset the token each time.
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
              FirebasePushNotificationManager.Initialize(this,false);
#endif

            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                //Android.Widget.Toast.MakeText(this.ApplicationContext, "Clicked on the notification", Android.Widget.ToastLength.Short).Show();
                Console.WriteLine($"Received {p.Data}");
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                Android.Widget.Toast.MakeText(this.ApplicationContext, "Clicked on the notification", Android.Widget.ToastLength.Short).Show();
                Console.WriteLine($"Clicked the notification");
            };
        }
    }
}