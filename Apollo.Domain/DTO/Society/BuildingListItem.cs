using Apollo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class BuildingListItem : IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static Expression<Func<Domain.Entity.Society.Building, BuildingListItem>> Projection
        {
            get
            {
                return x => new BuildingListItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive.Value
                };
            }
        }
    }


}
