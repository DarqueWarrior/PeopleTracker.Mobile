using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleTracker.Mobile.Models;
using Xamarin.Forms;

namespace PeopleTracker.Mobile.Views.People
{
   public partial class Details : ContentPage
   {
      private readonly Repository repo;

      public Details()
      {
         InitializeComponent();

         repo = new Repository();
      }

      protected void OnDeleteClicked(object sender, EventArgs e)
      {
         Device.BeginInvokeOnMainThread(async () =>
         {
            var result = await this.DisplayAlert("Delete", "Are you sure you want to delete this person?", "Yes", "No");
            if (result)
            {
               await repo.RemovePerson(BindingContext as Person);
               await Navigation.PopAsync();
            }
         });
      }

      protected void OnEditItemClicked(object sender, EventArgs e)
      {
         Navigation.PushAsync(new CreateOrEdit(false) { BindingContext = this.BindingContext });
      }
   }
}
