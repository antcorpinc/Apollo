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
        public Guid SocietyId { get; set; }
        public string BuildingName { get; set; }
        public Guid BuildingId { get; set; }
        public string FlatName { get; set; }
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<UserApplicationRole> UserAppRoles = new List<UserApplicationRole>();
        
        public static Expression<Func<Domain.Entity.SocietyUser, SocietyUserListItem>> Projection
        {
            get
            {
                return x => new SocietyUserListItem()
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    IsActive = x.User.IsActive.Value,
                    Email = x.User.Email,
                    UserTypeId = x.User.UserTypeId,
                    SocietyName = x.Society.Name,
                    SocietyId = x.SocietyId,
                    BuildingName = x.Building.Name,
                    BuildingId = x.BuildingId,
                    FlatName = x.Flat.Name,
                    FlatId = x.FlatId,
                    UserId = x.UserId,
                    UserAppRoles = x.User.UserAppRoleMappings.AsQueryable().Select(UserApplicationRole.Projection)
                };
            }
        }
    }
}
