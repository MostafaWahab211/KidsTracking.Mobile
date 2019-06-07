using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsTracking.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Photo : ContentPage
    {
        public Photo()
        {
            InitializeComponent();
            WebRequest request = WebRequest.Create("");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            img.Source = ImageSource.FromStream(() => { return stream; });
        }
    }
}