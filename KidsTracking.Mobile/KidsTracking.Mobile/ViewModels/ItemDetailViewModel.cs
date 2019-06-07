using System;

using KidsTracking.Mobile.Models;

namespace KidsTracking.Mobile.ViewModels
{
    public class KidDetailViewModel : BaseViewModel
    {
        public Kid Item { get; set; }
        public KidDetailViewModel(Kid item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
