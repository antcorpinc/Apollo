using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
    public class SupportUser : Base.User
    {
        SupportUser(){
            this.UserApplicationRole = new List<Base.UserApplicationRole>();
        }

        public ICollection<Base.UserApplicationRole> UserApplicationRole { get; set; }
    }
}