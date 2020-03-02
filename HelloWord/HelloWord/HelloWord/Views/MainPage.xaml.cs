using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWord
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

           // IconImage.Source = ImageSource.FromResource("HelloWord.Assets.Images.ant.png", assembly);
                
        }

     
    

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool UserNameEmpty = string.IsNullOrEmpty(NameEntry.Text);
            bool PasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);

            if (UserNameEmpty || PasswordEmpty)
            {

            }
            else
            {
                Navigation.PushAsync(new TransactionsPage());
            }
            
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
