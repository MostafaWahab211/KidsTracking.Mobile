using System;

using KidsTracking.Mobile.Models;

namespace KidsTracking.Mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Kid Item { get; set; }
        public ItemDetailViewModel(Kid item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
