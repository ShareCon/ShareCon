using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        
        public HistoryPage()
        {
            InitializeComponent();
            
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            using (SQLiteConnection con = new SQLiteConnection(App.databaselocation))
            {
                con.CreateTable<PostClass>();
                var post = con.Table<PostClass>().ToList();
                PostListView.ItemsSource = post;
            }
               
           
            
        }

        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selecteddata = PostListView.SelectedItem as PostClass;

            if (selecteddata != null)
                Navigation.PushAsync(new UpdateDeletePage(selecteddata));
            else { }
            
        }
    }
}