using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using HelloWord.Logic;


namespace HelloWord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
       public PostClass dbClass = new PostClass();
        public NewTravelPage()
        {
            InitializeComponent();
            
        }
        
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await VenueLogicClass.GetVenues(position.Latitude,position.Longitude);
            VenueListView.ItemsSource = venues;
            

        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            dbClass.Experience = ExperienceEntry.Text.Trim();
            using (SQLiteConnection connect = new SQLiteConnection(App.databaselocation))
            {

                connect.CreateTable<PostClass>();

                int InsertedRows = connect.Insert(dbClass);


                if (InsertedRows > 0)
                    DisplayAlert("Success", "Experience Saved", "Ok");
                else
                    DisplayAlert("Failed", "Failed to Save Experience", "Ok");
            }
        }
    }
}