using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Geolocator;

using Plugin.Permissions.Abstractions;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool haslocationPermission = false;
        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
         
         }
        
        private async void GetPermissions()
        {
             try
            { 
            var status = await CrossPermissions.Current.RequestPermissionAsync<LocationWhenInUsePermission>();
             
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                {
                    await DisplayAlert("Permission", "requesting your location", "ok");
                }
                
                var statue = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                if (statue.ContainsKey(Permission.LocationWhenInUse))
                {
                      
                    status = statue[Permission.LocationWhenInUse];
                }

            }


            if (status == PermissionStatus.Granted)
            {
                    haslocationPermission = true;
                    LocationsMap.IsShowingUser = true;
                    GetLocation();
            }
            else
                await DisplayAlert("Permission", "Permission Request denied", "ok");

           }
            catch(Exception ex)
            {
               await DisplayAlert("Error", ex.Message, "ok");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (haslocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero,100);
            }

            GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        void Locator_PositionChanged(Object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {

            if (haslocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var Currentposition = await locator.GetPositionAsync();

                MoveMap(Currentposition);
            }
        }

        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            var Theposition = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var Map = new Xamarin.Forms.Maps.MapSpan(Theposition,1,1);
            

            var pin = new Xamarin.Forms.Maps.Pin()
            {
                Type = Xamarin.Forms.Maps.PinType.Place,
                Position=Theposition,
                Label="Traore"


            };

            LocationsMap.MoveToRegion(Map);
            LocationsMap.Pins.Add(pin);

             pin.Clicked += async (sender, e) => {
                await DisplayAlert("Test", "Test", "test");
            };
        }

        private void Pin_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}