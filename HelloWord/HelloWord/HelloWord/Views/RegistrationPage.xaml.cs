using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloWord.ViewModels;
using HelloWord.Model;
using HelloWord.RestServices;
using HelloWord.UserServices;


namespace HelloWord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
       // public Users test = new Users();
       // public UserDataBox test2 = new UserDataBox();
       //public RestClient<Users> restClient = new RestServices.RestClient<Users>();
       // public UserServices.UserServices Userservice = new UserServices.UserServices();
       
        public RegistrationPage()
        {
            InitializeComponent();
          
        }
       
        
        private void SignUp_Clicked(object sender, EventArgs e)
        {

            // restClient.PutAsync()

            
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
           
           
        }

        //public async Task SaveUser ()
        //{

        // // await Userservice.PostUsers(collectUserData());
        //}

        //public List<Users> collectUserData()
        //{
        //    var UserData = new List<Users>();

        //    UserData.Add(new Users
        //    {
        //        FullOrCompanyName = FullName.Text.Trim(),
        //        Email = Email.Text.Trim(),
        //        StreetNameAndNumber = StreetName.Text.Trim(),
        //        City = CityName.Text.Trim(),
        //        Country = CountryName.Text.Trim(),
        //        PhoneNumber = PhoneNumber.Text.Trim(),
        //        Password = Password.Text.Trim(),
        //        // confirmPassword = ConfirmPassword.Text.Trim(),

        //    });

            
        //    return UserData;
        //}


        //public static bool GetUSerData()
        //{

        //    return UserDataBox.UserDataAdded(user);

        //}






    }

}