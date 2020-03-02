using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HelloWord.Helpers
{
   public class ConstantsClass
    {
        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";

        public const string CLIENT_ID = "ZPQJKFNVV3GOYNWOXQDQXV3BPSH05VPJFINGMJZEBHAPZVAR";

        public const string CLIENT_SECRET = "5GVHAYY003EFYYJO5I534RQJ1G0QKGDKMYOBSXX0E425RY1V";

        //public const string WebserviceUrl = "http://192.168.2.27:454/api/Users/";
        // public const string WebserviceUrl = "https://localhost:44386/api/Users/";
        // public const string WebserviceUrl = "http://10.0.2.2:44386/api/Users/";

        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:57483" : "https://localhost:57483";
        public static string WebserviceUrl = BaseAddress + "/api/Users/{0}";

        public const string SavetoDBWebserviceUrl = "https://localhost:44386/UsersMvc/Create/";

        public const string GetUserID = "https://localhost:44386/api/Users/5";
    }
}
