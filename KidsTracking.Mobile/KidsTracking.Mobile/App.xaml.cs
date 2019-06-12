using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KidsTracking.Mobile.Services;
using KidsTracking.Mobile.Views;
using System.Timers;

namespace KidsTracking.Mobile
{
    public partial class App : Application
    {
        System.Timers.Timer timer = new System.Timers.Timer();

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            if (Xamarin.Essentials.Preferences.Get("token", "") == "")
            {
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                MainPage = new MainPage();
                timer.Elapsed += Timer_ElapsedAsync;
                timer.Start();
            }
        }

        private async void Timer_ElapsedAsync(object sender, ElapsedEventArgs e)
        {
            Xamarin.Essentials.Location location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            if (location != null)
                location = await Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();
            System.Net.WebRequest webRequest = System.Net.WebRequest.Create("http://kidstracking.azurewebsites.net/api/Parent/UpdateLocation");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
