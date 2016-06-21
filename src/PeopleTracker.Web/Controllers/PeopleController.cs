using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PeopleTracker.Web.Models;

namespace PeopleTracker.Web.Controllers
{
   public class PeopleController : Controller
   {
      private readonly IRepository db;
      private readonly IOptions<SiteOptions> siteOptions;

      public PeopleController(IRepository repo, IOptions<SiteOptions> options)
      {
         db = repo;
         siteOptions = options;
      }

      public IActionResult Create()
      {
         ViewData["WebApiBaseUrl"] = siteOptions?.Value.WebApiBaseUrl;

         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Create([Bind("ID", "FirstName", "LastName")] Person person)
      {
         ViewData["WebApiBaseUrl"] = siteOptions.Value.WebApiBaseUrl;

         if (ModelState.IsValid)
         {
            await db.AddPerson(person);
            return RedirectToAction("Index");
         }

         return View(person);
      }

      public async Task<IActionResult> Delete(int? id)
      {
         ViewData["WebApiBaseUrl"] = siteOptions.Value.WebApiBaseUrl;

         if (id == null)
         {
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
         }

         var result = await db.GetPeople();

         var person = result.First(p => p.ID == id);

         if (person == null)
         {
            return NotFound();
         }

         return View(person);
      }

      [HttpPost]
      [ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         ViewData["WebApiBaseUrl"] = siteOptions.Value.WebApiBaseUrl;

         var result = await db.GetPeople();

         var person = result.FirstOrDefault(p => p.ID == id);
         if (person == null)
         {
            return NotFound();
         }

         await db.RemovePerson(person);

         return RedirectToAction("Index");
      }

      public async Task<ActionResult> Details(int? id)
      {
         ViewData["WebApiBaseUrl"] = siteOptions.Value.WebApiBaseUrl;

         if (id == null)
         {
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
         }

         var result = await db.GetPeople();

         var person = result.FirstOrDefault(p => p.ID == id);
         if (person == null)
         {
            return NotFound();
         }

         return View(person);
      }

      public async Task<ActionResult> Edit(int? id)
      {
         ViewData["WebApiBaseUrl"] = siteOptions.Value.WebApiBaseUrl;

         if (id == null)
         {
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
         }

         var result = await db.GetPeople();
         var person = result.FirstOrDefault(p => p.ID == id);
         if (person == null)
         {
            return NotFound();
         }
         return View(person);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Edit([Bind("ID", "FirstName", "LastName")] Person person)
      {
         ViewData["WebApiBaseUrl"] = siteOptions.Value.WebApiBaseUrl;

         if (ModelState.IsValid)
         {
            await db.UpdatePerson(person);
            return RedirectToAction("Index");
         }
         return View(person);
      }

      public async Task<ActionResult> Index()
      {
         ViewData["WebApiBaseUrl"] = siteOptions.Value.WebApiBaseUrl;
         var result = await db.GetPeople();
         return View(result.ToList());
      }
   }
}
