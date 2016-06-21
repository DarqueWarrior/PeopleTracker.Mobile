using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace PeopleTracker.Web.Models
{
   public class Repository : IRepository
   {
      private readonly IOptions<SiteOptions> siteOptions;

      public Repository(IOptions<SiteOptions> options)
      {
         siteOptions = options;
      }

      public async Task<IEnumerable<Person>> GetPeople()
      {
         var people = new List<Person>();

         try
         {
            // RestUrl = "http://peopletrackerdotnetservice-dev.azurewebsites.net/api/people"
            var client = GetClient();
            var response = await client.GetAsync("api/People");
            if (response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();
               people = JsonConvert.DeserializeObject<List<Person>>(content);
            }
         }
         catch (Exception ex)
         {
            Debug.WriteLine(@"				ERROR {0}", ex.Message);
         }

         return people;
      }

      public async Task<bool> AddPerson(Person person)
      {
         var client = GetClient();
         var personJson = JsonConvert.SerializeObject(person);
         var content = new StringContent(personJson, Encoding.UTF8, "application/json");
         var response = await client.PostAsync("api/People", content);

         return response.IsSuccessStatusCode;
      }

      public async Task RemovePerson(Person person)
      {
         var client = GetClient();

         // If you don't wait you will return to the list page before the item
         // is removed.
         await client.DeleteAsync("api/People/" + person.ID);
      }

      public async Task<bool> UpdatePerson(Person person)
      {
         var client = GetClient();
         var personJson = JsonConvert.SerializeObject(person);
         var content = new StringContent(personJson, Encoding.UTF8, "application/json");
         var response = await client.PutAsync("api/People/" + person.ID, content);

         return response.IsSuccessStatusCode;
      }

      private HttpClient GetClient()
      {
         var client = new HttpClient { MaxResponseContentBufferSize = 256000, BaseAddress = new Uri(siteOptions.Value.WebApiBaseUrl) };

         // Add an Accept header for JSON format.
         client.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));

         return client;
      }
   }
}
