using System;

namespace PeopleTracker.Mobile.Views.Home
{
   public partial class Index
   {
      public Index()
      {
         InitializeComponent();
      }

      protected void OnPeopleClicked(object sender, EventArgs e)
      {
         Navigation.PushAsync(new People.Index());
      }

      private void OnContactClicked(object sender, EventArgs e)
      {
         Navigation.PushAsync(new Contact());
      }

      private void OnAboutClicked(object sender, EventArgs e)
      {
         Navigation.PushAsync(new About());
      }
   }
}
