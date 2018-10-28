using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apollo.Domain.DTO.Base
{
    public class User : BaseModel
    {
        public User()
        {
           
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string PhoneNumber {get;set;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}