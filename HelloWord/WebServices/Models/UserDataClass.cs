using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace HelloWord.ViewModels
{
  


     public class Users 
    {

        public int ID { get; set; }
        public string FullOrCompanyName { get; set; }
            public string Email { get; set; }
            public string StreetNameAndNumber { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string PhoneNumber { get; set; }

            public string Password { get; set; }

            public string Image { get; set; }

            public string fullname()
            {
                string name = FullOrCompanyName.Trim();
                return name;
            }
    }
    
}
