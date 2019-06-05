using System;

namespace KidsTracking.Mobile.Models
{
    public class Kid
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; } 
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}