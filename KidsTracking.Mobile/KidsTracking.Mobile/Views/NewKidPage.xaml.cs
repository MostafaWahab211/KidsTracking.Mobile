using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KidsTracking.Mobile.Models;
using KidsTracking.Mobile.ViewModels;
using System.Net;
using System.IO;

namespace KidsTracking.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class NewKidPage : ContentPage
    {
        public NewKidViewModel Item { get; set; }

        public NewKidPage()
        {
            InitializeComponent();

            //Item = new Kid
            //{
            //    Text = "Item name",
            //    Description = "This is an item description."
            //};

            BindingContext = Item;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", Item);
            string Json = Newtonsoft.Json.JsonConvert.SerializeObject(Item);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(Json);
            WebRequest request = WebRequest.Create("http://kidstracking.azurewebsites.net/Kid/Register");
            WebHeaderCollection webHeader = new WebHeaderCollection();
            request.ContentType ="application/Json";
            request.Headers.Add(HttpRequestHeader.Authorization, Xamarin.Essentials.Preferences.Get("token", ""));
            Stream stream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(Json);
            writer.Close();
            WebResponse response = request.GetResponse();
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}