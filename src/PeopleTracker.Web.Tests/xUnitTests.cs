using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PeopleTracker.Preview.Tests
{
   // This project can output the Class library as a NuGet Package.
   // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
   public class PeopleControllerTests
   {
      [Fact]
      public void Create()
      {
         // Arrange
         var target = new PeopleTracker.Web.Controllers.PeopleController(null, null);

         // Act
         var result = target.Create();

         // Assert
         Assert.NotNull(result);
      }
   }
}
