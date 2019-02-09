using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.User
{
    public class ApplicationListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public static Expression<Func<Domain.Entity.Application, ApplicationListItem>> Projection
        {
            get
            {
                return x => new ApplicationListItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive
                };
            }
        }
    }
}
