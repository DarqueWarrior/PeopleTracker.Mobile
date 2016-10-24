using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PeopleTracker.Mobile.Tests
{
   [TestFixture(Platform.Android)]
#if (!DEBUG)
   [TestFixture(Platform.iOS)]
#endif
   public class Tests
   {
      IApp app;
      Platform platform;

      public Tests(Platform platform)
      {
         this.platform = platform;
      }

      [SetUp]
      public void BeforeEachTest()
      {
         app = AppInitializer.StartApp(platform);
      }

      [Test]
      public void AppLaunches()
      {
         app.Screenshot("First screen.");
      }

      [Test]
      public void Add_Person()
      {
         app.Screenshot("Home Page");
         app.Tap(x => x.Marked("People"));
         app.Screenshot("People List");
         app.Tap(x => x.Marked("Create"));
         app.Screenshot("Create Form");
         app.Tap(x => x.Class("EntryEditText"));
         app.EnterText(x => x.Class("EntryEditText"), "Donovan");
         app.Screenshot("Enter first name");
         app.Tap(x => x.Class("EntryEditText").Index(2));
         app.EnterText(x => x.Class("EntryEditText").Index(2), "Brown");
         app.Screenshot("Enter last name");
         app.Tap(x => x.Marked("Save"));
         app.Screenshot("Save Person");
      }
   }
}

