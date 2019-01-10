using Apollo.Core.Interface;
using Apollo.Domain.Entity.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface IFlatRepository : IRepository<Flat, Guid>
    {
         Task<bool>  IsFlatInInSocietyBuildingExistsAsync(Guid societyId, Guid buildingId, Guid flatId);
    }
}
