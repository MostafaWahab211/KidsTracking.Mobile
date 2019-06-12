using System;
using System.Collections.Generic;
using System.Text;

namespace KidsTracking.Mobile.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string grant_type = "password";
        public string token { get; set; }
    }
}
