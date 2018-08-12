using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
   public class UserDetails
    {
        public UserDetails()
        {
            ApplicationPermissions = new List<ApplicationPermission>();
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool? IsActive { get; set; }
        public int UserTypeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public List<ApplicationPermission> ApplicationPermissions { get; set; }

    }
}
