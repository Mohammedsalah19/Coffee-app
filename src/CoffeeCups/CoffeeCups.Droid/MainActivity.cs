﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace CoffeeCups.Droid
{
    [Activity(Label = "CoffeeCups", Icon = "@drawable/icon", MainLauncher = true, Theme = "@style/MyTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate(bundle);
            Forms.Init(this, bundle);

            CurrentPlatform.Init();

#if ENABLE_TEST_CLOUD
    //Mapping StyleID to element content descriptions
            Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
            if (!string.IsNullOrWhiteSpace(e.View.StyleId)) {
            e.NativeView.ContentDescription = e.View.StyleId;
            }
            };
#endif

            LoadApplication(new App());
        }
    }
}