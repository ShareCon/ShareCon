using System;
using System.Collections.Generic;
using System.Text;
using HelloWord.ViewModels;
using System.Threading.Tasks;
using HelloWord.RestServices;
using HelloWord;


namespace HelloWord.UserServices
{
    public  class UserServices
    {

        public async Task<List<Users>> GetUsersAsync()
        {
            RestClient<Users> restClient = new RestClient<Users>();
            var getUsers = await restClient.GetAsync();
            return getUsers;
        }

        public async Task PostUserAsyncs(Users NewUser)
        {

           
            RestClient<Users> restclient = new RestClient<Users>();
            var Result = await restclient.PostAsync(NewUser);
            
        }

        public async Task<bool> PutUserAsync(int ID, Users t)
        {
            RestClient<Users> restclient = new RestClient<Users>();
            var result = await restclient.PutAsync(ID, t);
            return result;

        }

        public async Task<bool> DeleteUserAsync(int ID)
        {
            RestClient<Users> restclient = new RestClient<Users>();
            var result = await restclient.DeleteAsync(ID);
            return result;

        }

     

    }
}
