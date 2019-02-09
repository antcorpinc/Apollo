using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.User
{
   public  class ApplicationRoleListItem
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }

        public string ApplicationName { get; set; }

        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public static Expression<Func<Domain.Entity.ApplicationRole, ApplicationRoleListItem>> Projection
        {
            get
            {
                return x => new ApplicationRoleListItem()
                {
                    Id = x.Id,
                    ApplicationId = x.ApplicationId,
                    ApplicationName = x.Application.Name,
                    RoleId = x.RoleId,
                    RoleName = x.Role.Name                    
                };
            }
        }

    }
}
