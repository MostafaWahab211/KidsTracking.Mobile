using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using KidsTracking.Mobile.Models;
using KidsTracking.Mobile.Views;

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
                var items = await DataStore.GetItemsAsync(true);
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