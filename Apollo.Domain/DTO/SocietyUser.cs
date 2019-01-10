using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
   public class SocietyUser : Base.User
    {
        public SocietyUser()
        {
            this.UserApplicationRole = new List<Base.UserApplicationRole>();
        }

        public ICollection<Base.UserApplicationRole> UserApplicationRole { get; set; }

        // ToDO: Had to change bcos of name conflict
        public Base.SocietyUser  SocietyUserDetail { get; set; }

        public string SocietyName { get; set; }
        public string BuildingName { get; set; }
        public string FlatName { get; set; }
    }
}
