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
    public partial class UpdateDeletePage : ContentPage
    {
        PostClass selecteData;
        public UpdateDeletePage(PostClass selecteddata)
        {
            InitializeComponent();
            this.selecteData = selecteddata;
            ToModifyText.Text = selecteData.Experience;
        }

    
       

        private void Delete_Clicked(object sender, EventArgs e)
        {
            selecteData.Experience = ToModifyText.Text;
            using (SQLiteConnection connect = new SQLiteConnection(App.databaselocation))
            {

                connect.CreateTable<PostClass>();

                int InsertedRows = connect.Delete(selecteData);


                if (InsertedRows > 0)
                    DisplayAlert("Success", "Experience deleted", "Ok");
                else
                    DisplayAlert("Failed", "Failed to Save delete Experience", "Ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

            selecteData.Experience = ToModifyText.Text;
            using (SQLiteConnection connect = new SQLiteConnection(App.databaselocation))
            {

                connect.CreateTable<PostClass>();

                int InsertedRows = connect.Update(selecteData);


                if (InsertedRows > 0)
                    DisplayAlert("Success", "Experience updated", "Ok");
                else
                    DisplayAlert("Failed", "Failed to Save updated Experience", "Ok");
            }

        }
    }
}