using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Base
{
    public class UserList
    {
        public UserList()
        {
            this.UserApplicationRole = new List<DTO.UserApplicationRole>();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        
        public ICollection<DTO.UserApplicationRole> UserApplicationRole { get; set; }
        
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
