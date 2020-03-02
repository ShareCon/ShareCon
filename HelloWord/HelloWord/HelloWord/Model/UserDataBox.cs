using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using HelloWord;
using HelloWord.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;


namespace HelloWord.Model
{
    public class UserDataBox /*: INotifyPropertyChanged*/
    {
        public Users users = new Users();
        //public RegistrationPage test = new RegistrationPage();
        public bool UserDataAdded()
        {
         
           // test.collectUserData();
            var DBconnectionString = "DataSource=DESKTOP-ATD0DH4;initial catalog =SHARECONDB;Integrated Security=true";
            var InsertUser = "INSERT INTO Users (Email,FullName,StreetNameAndNumber,City,Country,PhoneNumber,Password,DateCreated,Picture) VALUES ('@Email','@FullName','@StreetNameAndNumber','@City','@Country','@PhoneNumber','@Password','@DateCreated','@Picture')";

            InsertUser = InsertUser.Replace("@Email", users.Email)
                                   .Replace("@FullName", users.FullOrCompanyName)
                                   .Replace("@StreetNameAndNumber", users.StreetNameAndNumber)
                                   .Replace("@City", users.City)
                                   .Replace("@Country", users.Country)
                                   .Replace("@PhoneNumber", users.PhoneNumber)
                                   .Replace("@Password", users.Password)
                                   .Replace("@DateCreated", DateTime.Now.ToString("F"))
                                   .Replace("@Picture", users.Image);

            SqlConnection connection = new SqlConnection(DBconnectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(InsertUser, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
              
                return true;
            }
            catch (Exception)
            {

                //throw;
                return false;
            }
            
        }

       

    }
}
