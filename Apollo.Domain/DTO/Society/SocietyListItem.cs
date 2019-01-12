using Apollo.Core.Interface;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    // Info: This is prpjection class - Refer Ben Cull Blog for details
    // https://benjii.me/2018/01/expression-projection-magic-entity-framework-core/
    public class SocietyListItem: IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
       
        public static Expression<Func<Domain.Entity.Society.Society, SocietyListItem>> Projection
        {
            get
            {
                return x => new SocietyListItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Area = x.Area.Name,
                    City = x.City.Name,
                    State = x.State.Name,
                    
                };
            }
        }
    }
}
