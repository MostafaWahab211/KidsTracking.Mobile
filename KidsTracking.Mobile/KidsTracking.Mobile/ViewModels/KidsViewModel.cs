using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using KidsTracking.Mobile.Models;
using KidsTracking.Mobile.Views;
using System.Net;

namespace KidsTracking.Mobile.ViewModels
{
    public class KidsViewModel : BaseViewModel
    {
        public ObservableCollection<Kid> Kids { get; set; }
        public Command LoadItemsCommand { get; set; }

        public KidsViewModel()
        {
            Title = "Kids";
            Kids = new ObservableCollection<Kid>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewKidPage, Kid>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Kid;
                Kids.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Kids.Clear();
                WebRequest request = WebRequest.Create("http//:kidstracking.azurewebsites.net/api/parent/GetAllKids");
                request.Headers.Add(HttpRequestHeader.Authorization, Xamarin.Essentials.Preferences.Get("token", ""));
                WebResponse response = request.GetResponse();
                System.IO.Stream stream = response.GetResponseStream();
                byte[] data = new byte[(int)stream.Length];
                stream.Read(data, 0, (int)stream.Length);
                string Json = System.Text.Encoding.UTF8.GetString(data);
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.IEnumerable<Kid>>(Json);
                foreach (var item in items)
                {
                    Kids.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}