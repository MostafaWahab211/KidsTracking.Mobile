using KidsTracking.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Newtonsoft.Json;

namespace KidsTracking.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_ClickedAsync(object sender, EventArgs e)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = Email.Text;
            loginViewModel.Password = Password.Text;
            string JsonData = JsonConvert.SerializeObject(loginViewModel);
            WebRequest request = WebRequest.Create("http://kidstracking.azurewebsites.net/Token");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "post";
            Stream stream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(JsonData);
            writer.Close();
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            byte[] data = new byte[responseStream.Length];
            responseStream.Read(data, 0, (int)responseStream.Length);
            string jsonToken = Encoding.UTF8.GetString(data);
            loginViewModel = JsonConvert.DeserializeObject<LoginViewModel>(jsonToken);
            Xamarin.Essentials.Preferences.Set("token", loginViewModel.token);
            App.Current.MainPage = new MainPage();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}