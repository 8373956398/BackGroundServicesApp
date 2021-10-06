using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ServicesApp.Droid
{
    [Service(Label = "BackgroundServices")]
    public class BackgroundServices : Service
    {
        int counter = 0;
        bool isRunningTimer = true;
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                MessagingCenter.Send<string>(counter.ToString(), "Keytocounter");
                counter += 1;
                return isRunningTimer;
            });
            return StartCommandResult.Sticky;
        }
       
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override void OnDestroy()
        {
            StopSelf();
            counter = 0;
            isRunningTimer = false;
            base.OnDestroy();
        }

    }
}