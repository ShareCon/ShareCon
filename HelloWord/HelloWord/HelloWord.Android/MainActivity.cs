using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Permissions;
using Android.OS;
using System.Net.Http;
using System.Net.Http.Headers;


namespace HelloWord.Droid
{
    [Activity(Label = "HelloWord", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            //Database Location
            //File file = new File(Environment.GetExternalStoragePublicDirectory() + "/" + File.separator + "test.txt");
            //string DatabaseName = "Datastored";
            //string DatabasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //string DBFullPath = Path.Combine(DatabasePath,DatabaseName);

            //this part handles certificate to be able to use localhost from the emulator

            //  GetInsecureHandler();
#if DEBUG
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
            {
                if (certificate.Issuer.Equals("CN=localhost"))
                    return true;
                return sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
            };
#endif



            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        //public HttpClientHandler GetInsecureHandler()
        //{
        //    var handler = new HttpClientHandler();
        //    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        //    {
        //        if (cert.Issuer.Equals("CN=localhost"))
        //            return true;
        //        return errors == System.Net.Security.SslPolicyErrors.None;
        //    };
        //    return handler;
        //}
    }
}