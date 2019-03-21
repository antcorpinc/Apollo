using Apollo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.User
{
    public class FeatureListItem : IIdentifiableModel<int>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public int? ParentFeatureId { get; set; }
        public string Privileges { get; set; }
        public IList<FeatureListItem> SubFeature { get; set; } = new List<FeatureListItem>();

        public static Expression<Func<Domain.Entity.Feature, FeatureListItem>> Projection
        {
            get
            {
                return x => new FeatureListItem()
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    Name = x.Name,
                    Description = x.Description,
                    Order = x.Order,
                    ParentFeatureId = x.ParentFeatureId,
                    Privileges =
                    x.FeatureTypeRolePrivilege.AsQueryable()
                    .Select(ftp => ftp.Privileges).FirstOrDefault()
                };
            }
        }
    }
}
