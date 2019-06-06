using System;

namespace KidsTracking.Mobile.Models
{
    public class Kid
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; } 
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}