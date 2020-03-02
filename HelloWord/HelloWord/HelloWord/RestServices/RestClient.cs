using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using HelloWord.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace HelloWord.RestServices
{
    public class RestClient<T>
    {
        //collect the list of users from the DB
        public async Task<List<T>> GetAsync()
        {
            var HttpClient = new HttpClient();
            var Json = await HttpClient.GetStringAsync(ConstantsClass.WebserviceUrl);
            var TaskModels = JsonConvert.DeserializeObject<List<T>>(Json);
            return TaskModels;


        }

        //insert user(s)
        public async Task<bool> PostAsync(T t)
        {
            //var HttpClient = new HttpClient();
            var HttpClient = new HttpClient(new HttpClientHandler());
            var Json = JsonConvert.SerializeObject(t);
            HttpContent httpContent= new StringContent(Json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var Result = await HttpClient.PostAsync(ConstantsClass.WebserviceUrl, httpContent);
            var Result = await HttpClient.PostAsync(ConstantsClass.SavetoDBWebserviceUrl, httpContent);
            return Result.IsSuccessStatusCode;
        }

        //update user
        public async Task<bool> PutAsync(int ID,T t)
        {
            var HttpClient = new HttpClient();
            var Json = JsonConvert.SerializeObject(t);
            HttpContent httpcontent = new StringContent(Json);
            httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var Result = await HttpClient.PutAsync(ConstantsClass.WebserviceUrl+ID, httpcontent);
            return Result.IsSuccessStatusCode;


        }

        //Delete User
        public async Task<bool> DeleteAsync(int ID)
        {
            var HttpClient = new HttpClient();
            var Result = await HttpClient.DeleteAsync(ConstantsClass.WebserviceUrl + ID);
            return Result.IsSuccessStatusCode;


        }

        


    }
}
