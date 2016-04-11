using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleTracker.Web.Models
{
   public class Person
   {
      public int ID { get; set; }

      [Display(Name = "First Name")]
      public string FirstName { get; set; }

      [Display(Name = "Last Name")]
      public string LastName { get; set; }

      [Display(Name = "Middle Name")]
      public string MiddleName { get; set; }
   }
}
