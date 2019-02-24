using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO
{
    public class UserApplicationRole : Base.UserApplicationRole
    {
        public string ApplicationName { get; set; }

        public string RoleName { get; set; }


        
public static Expression<Func<Domain.Entity.UserAppRoleMapping, UserApplicationRole>> Projection
        {
            get
            {
                return x => new UserApplicationRole()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ApplicationId = x.Application.Id,
                    ApplicationName = x.Application.Name,
                    RoleId = x.Role.Id,
                    RoleName = x.Role.Name
                };
            }
        }
    }
}
