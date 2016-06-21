using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace PeopleTracker.Web.Controllers
{
   public class HomeController : Controller
   {
      private readonly IOptions<SiteOptions> siteOptions;

      public HomeController(IOptions<SiteOptions> options)
      {
         this.siteOptions = options;
      }

      public IActionResult Index()
      {
         SetCopyright();

         return View();
      }

      public IActionResult About()
      {
         SetCopyright();

         ViewData["Message"] = "People Tracker is a demo application that shows the power of Microsoft DevOps.";

         return View();
      }

      public IActionResult Contact()
      {
         SetCopyright();

         ViewData["Message"] = "Follow me on Twitter to stay connected to Microsoft DevOps.";

         return View();
      }

      public IActionResult Error()
      {
         SetCopyright();

         return View("~/Views/Shared/Error.cshtml");
      }

      private void SetCopyright()
      {
         ViewData["WebApiBaseUrl"] = string.Format("{0} - build: {1}", this.siteOptions.Value.WebApiBaseUrl, this.siteOptions.Value.BuildNumber);
      }
   }
}
