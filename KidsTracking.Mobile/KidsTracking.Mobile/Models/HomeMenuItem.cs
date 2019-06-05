using System;
using System.Collections.Generic;
using System.Text;

namespace KidsTracking.Mobile.Models
{
    public enum MenuItemType
    {
        Profile,
        Kids,
        Call,
        Location,
        Camera,
        ConnectUs,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
