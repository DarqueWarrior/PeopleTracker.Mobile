using System;
using PeopleTracker.Mobile.Models;
using Xamarin.Forms;

namespace PeopleTracker.Mobile.Views.People
{
   public partial class CreateOrEdit : ContentPage
   {
      private readonly bool isNew;

      /// <summary>
      ///  You need a temp user just in case the person decides to cancel
      ///  their changes.
      /// </summary>
      private Person temp;
      private Person original;

      public CreateOrEdit(bool isNew)
      {
         InitializeComponent();

         this.isNew = isNew;

         if (this.isNew)
         {
            this.Title = "Create";
            PageTitle.Text = "Create Person";
            this.BindingContext = new Person();
         }
      }

      protected override void OnBindingContextChanged()
      {
         base.OnBindingContextChanged();

         if (this.isNew)
         {
            return;
         }

         original = this.BindingContext as Person;

         temp = new Person
         {
            FirstName = ((Person)this.BindingContext).FirstName,
            LastName = ((Person)this.BindingContext).LastName
         };
      }

      protected async void OnSaveItemClicked(object sender, EventArgs e)
      {
         var repo = new Repository();

         if (isNew)
         {
            await repo.AddPerson(this.BindingContext as Person);
         }
         else
         {
            await repo.UpdatePerson(this.BindingContext as Person);
         }

         await Navigation.PopAsync();
      }

      protected async void OnCancelClicked(object sender, EventArgs e)
      {
         original.FirstName = temp.FirstName;
         original.LastName = temp.LastName;

         await Navigation.PopAsync();
      }
   }
}
