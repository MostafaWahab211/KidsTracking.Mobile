using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Iid;

namespace KidsTracking.Mobile.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    class FirebaseIIDService: FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
       
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }
        public override void OnCreate()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
        }
        void SendRegistrationToServer(string token)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create($"Http://LocalHost/API/Parent/MessageingToken/{token}");
            System.Net.WebResponse response = request.GetResponse();
        }
    }
}