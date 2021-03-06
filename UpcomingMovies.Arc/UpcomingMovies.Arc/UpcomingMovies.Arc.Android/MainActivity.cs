﻿using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Droid;

namespace UpcomingMovies.Arc.Droid
{
    [Activity(Name = "upComingMovies.Arc.MainActivity", Label = "ArcTouch - TheMoviesDB", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Constructor
                
        public MainActivity()
        {                
        }

        #endregion

        #region Events        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //FFImageLoading init
            CachedImageRenderer.Init(true);            

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

        #endregion
    }
}