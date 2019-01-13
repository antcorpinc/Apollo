using Apollo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class FlatListItem : IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Domain.Entity.Society.Flat, FlatListItem>> Projection
        {
            get
            {
                return x => new FlatListItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive.Value
                };
            }
        }
    }
}
