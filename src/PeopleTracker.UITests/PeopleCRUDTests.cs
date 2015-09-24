using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using OpenQA.Selenium.Remote;

namespace PeopleTracker.UITests
{
   [TestClass]
   public class PeopleCRUDTests
   {
      #region Fields
      
      private string baseURL;

      private RemoteWebDriver driver;

      private string browser;

      #endregion

      #region Public Properties

      /// <summary>
      ///Gets or sets the test context which provides
      ///information about and functionality for the current test run.
      ///</summary>
      public TestContext TestContext { get; set; }

      #endregion

      #region Public Methods and Operators

      [TestMethod]
      [TestCategory("UI")]
      public void AddPerson()
      {
         driver.Manage().Window.Maximize();
         driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

         driver.Navigate().GoToUrl(this.baseURL);
         driver.FindElementByLinkText("People").Click();
         driver.FindElementByLinkText("Create New").Click();
         driver.FindElementById("FirstName").Clear();
         driver.FindElementById("FirstName").SendKeys(browser);
         driver.FindElementById("LastName").Clear();
         driver.FindElementById("LastName").SendKeys("User");
         driver.FindElementByCssSelector("input.btn").Click();

         // Force chrome to slow down so the click is registered
         var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));
         wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
      }

      /// <summary>
      /// Use TestCleanup to run code after each test has run
      /// </summary>
      [TestCleanup()]
      public void MyTestCleanup()
      {
         driver.Quit();
      }

      [TestInitialize()]
      public void MyTestInitialize()
      {
         browser = this.TestContext.Properties["browser"] != null ? this.TestContext.Properties["browser"].ToString() : "ie";

         switch (browser)
         {
            case "firefox":
               driver = new FirefoxDriver();
               break;

            case "chrome":
               driver = new ChromeDriver();
               break;

            default:
               driver = new InternetExplorerDriver();
               break;
         }

         // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
         if (this.TestContext.Properties["webAppUrl"] != null)
         {
            this.baseURL = this.TestContext.Properties["webAppUrl"].ToString();
         }
         else
         {
            this.baseURL = "http://peopletrackerdockerhost-dev.westus.cloudapp.azure.com/";
         }
      }

      #endregion
   }
}
// modified