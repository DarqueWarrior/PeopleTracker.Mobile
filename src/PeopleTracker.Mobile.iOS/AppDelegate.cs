using Foundation;
using HockeyApp;
using UIKit;

namespace PeopleTracker.Mobile.iOS
{
   // The UIApplicationDelegate for the application. This class is responsible for launching the 
   // User Interface of the application, as well as listening (and optionally responding) to 
   // application events from iOS.
   [Register("AppDelegate")]
   public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
   {
      //
      // This method is invoked when the application has loaded and is ready to run. In this 
      // method you should instantiate the window, load the UI into it and then make the window
      // visible.
      //
      // You have 17 seconds to return from this method, or iOS will terminate your application.
      //
      public override bool FinishedLaunching(UIApplication app, NSDictionary options)
      {
         var manager = BITHockeyManager.SharedHockeyManager;
         manager.Configure("31e48480d1c1ebae6914cffc470e66e7");
         manager.StartManager();
         manager.Authenticator.AuthenticateInstallation();

         global::Xamarin.Forms.Forms.Init();
         LoadApplication(new App());

         return base.FinishedLaunching(app, options);
      }
   }
}
