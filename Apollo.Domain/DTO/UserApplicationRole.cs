using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
    public class UserApplicationRole : Base.UserApplicationRole
    {
        public string ApplicationName { get; set; }

        public string RoleName { get; set; }
    }
}
