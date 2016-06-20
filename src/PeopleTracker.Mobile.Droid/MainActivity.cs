using Android.App;
using Android.Content.PM;
using Android.OS;
using HockeyApp;
using HockeyApp.Metrics;

namespace PeopleTracker.Mobile.Droid
{
   [Activity(Label = "People Tracker", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
   public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
   {
      private const string Appid = "2c9d5a83a2b548b08280512c2df4351c";

      protected override void OnCreate(Bundle bundle)
      {
         TabLayoutResource = Resource.Layout.Tabbar;
         ToolbarResource = Resource.Layout.Toolbar;

         base.OnCreate(bundle);

         CrashManager.Register(this, Appid);
         FeedbackManager.Register(this, Appid);
         MetricsManager.Register(this, Application, Appid);
         
         global::Xamarin.Forms.Forms.Init(this, bundle);
         LoadApplication(new App());

         CheckForUpdates();
      }

      protected override void OnResume()
      {
         base.OnResume();
         CheckForUpdates();
      }

      private void CheckForUpdates()
      {
         // Remove this for store builds!
         UpdateManager.Register(this, Appid);
      }

      private void UnregisterManagers()
      {
         UpdateManager.Unregister();
      }

      protected override void OnPause()
      {
         base.OnPause();
         UnregisterManagers();
      }

      protected override void OnDestroy()
      {
         base.OnDestroy();
         UnregisterManagers();
      }
   }
}

