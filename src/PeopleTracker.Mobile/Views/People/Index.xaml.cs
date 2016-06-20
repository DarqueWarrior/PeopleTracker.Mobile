using System;
using System.Threading.Tasks;
using PeopleTracker.Mobile.Models;
using Xamarin.Forms;

namespace PeopleTracker.Mobile.Views.People
{
   public partial class Index : ContentPage
   {
      private readonly Repository repo;

      public Index()
      {
         InitializeComponent();

         repo = new Repository();
      }

      protected override async void OnAppearing()
      {
         base.OnAppearing();

         await FetchData();
      }

      protected void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
      {
         Navigation.PushAsync(new Details() { BindingContext = e.SelectedItem as Person });
      }

      protected void OnAddItemClicked(object sender, EventArgs e)
      {
         Navigation.PushAsync(new CreateOrEdit(true) { BindingContext = new Person() });
      }

      protected async void OnRefreshClicked(object sender, EventArgs e)
      {
         await FetchData();
      }

      private async Task FetchData()
      {
         listView.ItemsSource = await repo.GetPeople();
      }
   }
}
