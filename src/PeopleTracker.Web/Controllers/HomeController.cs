using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;

namespace PeopleTracker.Web.Controllers
{
   public class HomeController : Controller
   {
      private IOptions<SiteOptions> siteOptions;

      public HomeController(IOptions<SiteOptions> options)
      {
         this.siteOptions = options;
      }

      public IActionResult Index()
      {
         SetCopyright();

         return View();
      }

      private void SetCopyright()
      {
         ViewData["WebApiBaseUrl"] = string.Format("{0} - build: {1}", this.siteOptions.Value.WebApiBaseUrl, this.siteOptions.Value.BuildNumber);
      }

      public IActionResult About()
      {
         ViewData["Message"] = "People Tracker is a demo application that shows the power of Microsoft DevOps.";
         SetCopyright();

         return View();
      }

      public IActionResult Contact()
      {
         ViewData["Message"] = "Follow me on Twitter to stay connected to Microsoft DevOps.";
         SetCopyright();

         return View();
      }

      public IActionResult Error()
      {
         SetCopyright();
         return View("~/Views/Shared/Error.cshtml");
      }
   }
}
