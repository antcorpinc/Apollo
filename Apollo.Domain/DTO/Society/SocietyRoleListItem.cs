using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class SocietyRoleListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }


        // Add Projection here

        public static Expression<Func<Domain.Entity.SocietyRole, SocietyRoleListItem>> Projection
        {
            get
            {
                return x => new SocietyRoleListItem()
                {
                    Id = x.Role.Id,
                    Name = x.Role.Name,
                    IsActive = x.IsActive
                };
            }
        }

    }
}
