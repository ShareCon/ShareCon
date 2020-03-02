using System;
using System.Collections.Generic;
using System.Text;
using HelloWord.Model;
using HelloWord.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace HelloWord.Logic
{
    public class VenueLogicClass
    {
        public async static Task <List <VenueClass>> GetVenues(double latitude, double longitude) 
        {
            List<VenueClass> venuees = new List<VenueClass>();

            var url = VenueClass.GenerateURL(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                var Response= await client.GetAsync(url);
                var Json = await Response.Content.ReadAsStringAsync();

                var VenueRoot = JsonConvert.DeserializeObject<VenueClass>(Json);
               venuees=VenueRoot.response.venues as List<VenueClass>;
              
            }

           

            return venuees;
        }

    }
}
