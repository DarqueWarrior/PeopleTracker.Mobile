using System.Collections.Generic;

namespace PeopleTracker.Mobile.Models
{
   public interface IRepository
   {
      IEnumerable<Person> People { get; }

      bool AddPerson(Person person);

      void RemovePerson(Person person);

      bool UpdatePerson(Person person);
   }
}
