namespace PeopleTracker.DAL
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   public partial class Person
   {
      public int ID { get; set; }

      [Required]
      [Display(Name = "First Name")]
      [StringLength(50)]
      public string FirstName { get; set; }

      [Required]
      [Display(Name = "Last Name")]
      [StringLength(50)]
      public string LastName { get; set; }

      [Required]
      [Display(Name = "Middle Name")]
      [StringLength(50)]
      public string MiddleName { get; set; }
   }
}
