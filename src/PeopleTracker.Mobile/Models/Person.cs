using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PeopleTracker.Mobile.Models
{
   public partial class Person : INotifyPropertyChanged
   {
      private string firstName;
      private string lastName;
      private string middleName;
      public int ID { get; set; }

      public string FirstName
      {
         get { return firstName; }
         set
         {
            if (firstName != value)
            {
               firstName = value;
               OnPropertyChanged();
            }
         }
      }

      public string LastName
      {
         get { return lastName; }
         set
         {
            if (lastName != value)
            {
               lastName = value;
               OnPropertyChanged();
            }
         }
      }

      public string MiddleName
      {
         get { return middleName; }
         set
         {
            if (middleName != value)
            {
               middleName = value;
               OnPropertyChanged();
            }
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
