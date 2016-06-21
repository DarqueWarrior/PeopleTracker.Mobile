using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleTracker.Web.Models
{
   public interface IRepository
   {
      Task<IEnumerable<Person>> GetPeople();

      Task<bool> AddPerson(Person person);

      Task RemovePerson(Person person);

      Task<bool> UpdatePerson(Person person);
   }
}
