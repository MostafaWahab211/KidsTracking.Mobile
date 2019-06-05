using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KidsTracking.Mobile.Models;
using KidsTracking.Mobile.ViewModels;

namespace KidsTracking.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class KidDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public KidDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public KidDetailPage()
        {
            InitializeComponent();

            var item = new Kid
            {
                Name = "Item 1",
                Phone = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}