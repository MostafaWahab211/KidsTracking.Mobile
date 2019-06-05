using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KidsTracking.Mobile.Models;
using KidsTracking.Mobile.Views;
using KidsTracking.Mobile.ViewModels;

namespace KidsTracking.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class KidsPage : ContentPage
    {
        KidsViewModel viewModel;

        public KidsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new KidsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Kid;
            if (item == null)
                return;

            await Navigation.PushAsync(new KidDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewKidPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Kids.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}