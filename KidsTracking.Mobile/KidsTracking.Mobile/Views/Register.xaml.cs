using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using KidsTracking.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsTracking.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        RegisterViewModel ViewModel { get; set; }
        public Register()
        {
            InitializeComponent();
            BindingContext = ViewModel = new RegisterViewModel();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ViewModel);
            byte[] data = Encoding.UTF8.GetBytes(json);
            WebRequest request = WebRequest.Create("http://kidstracking.azurewebsites.net/api/Parent/Register");

            request.ContentType = "application/json";
            request.Method = "post";
            Stream stream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(stream);

            writer.Write(json);
            writer.Close();
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    stream = response.GetResponseStream();
                    stream.Read(data, 0, (int)stream.Length);
                    json = Encoding.UTF8.GetString(data);
                    error.Text = json;
                }
                await Navigation.PopAsync();
            }
            catch (WebException)
            {
                    stream = response.GetResponseStream();
                    stream.Read(data, 0, (int)stream.Length);
                    json = Encoding.UTF8.GetString(data);
                    error.Text = json;
                
            }
            
                
        }
    }
}