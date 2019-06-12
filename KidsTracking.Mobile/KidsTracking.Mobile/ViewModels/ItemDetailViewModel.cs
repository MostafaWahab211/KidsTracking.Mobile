using System;
using System.IO;
using System.Net;
using System.Text;
using KidsTracking.Mobile.Models;

namespace KidsTracking.Mobile.ViewModels
{
    public class KidDetailViewModel : BaseViewModel
    {
        public Kid Item { get; set; }
        public KidDetailViewModel(Kid item = null)
        {
            WebRequest request = WebRequest.Create($"http//kidstracking.azurewebsites.net/api/kid/findbyid/{item.Id}");
            request.Method = "post";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            byte[] data = new byte[stream.Length];
            stream.Write(data, 0, data.Length);
            string Json = Encoding.UTF8.GetString(data);
            Item = Newtonsoft.Json.JsonConvert.DeserializeObject<Kid>(Json);
        }
    }
}
