﻿
using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Restofit.UI;

namespace Restofit.Droid
{
    [Activity(Label = "Restofit", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ActionBar.SetIcon(new ColorDrawable(Android.Graphics.Color.Transparent));
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();

            LoadApplication(new App());
        }
    }
}

