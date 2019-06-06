using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KidsTracking.Mobile.Models;
using KidsTracking.Mobile.ViewModels;
using Xamarin.Forms.Maps;

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

            Position position = new Position(viewModel.Item.Latitude, viewModel.Item.Longitude);
            BindingContext = this.viewModel = viewModel;
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    position, Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = viewModel.Item.Name,
            };
            map.Pins.Add(pin);
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