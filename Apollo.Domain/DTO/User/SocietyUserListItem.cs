using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.User
{
   public class SocietyUserListItem: BaseUser
    {
        public SocietyUserListItem()
        {

        }
       public string SocietyName { get; set; }
        public string BuildingName { get; set; }
        public string FlatName { get; set; }
        public IEnumerable<UserApplicationRole> UserAppRoles = new List<UserApplicationRole>();
        
        public static Expression<Func<Domain.Entity.SocietyUser, SocietyUserListItem>> Projection
        {
            get
            {
                return x => new SocietyUserListItem()
                {
                    Id = x.User.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    IsActive = x.User.IsActive.Value,
                    Email = x.User.Email,
                    UserTypeId = x.User.UserTypeId,
                    SocietyName = x.Society.Name,
                    BuildingName = x.Building.Name,
                    FlatName = x.Flat.Name,
                    UserAppRoles = x.User.UserAppRoleMappings.AsQueryable().Select(UserApplicationRole.Projection)
                };
            }
        }
    }
}
