using Apollo.Core.Interface;
using Apollo.Domain.Entity.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface ISocietyRepository: IRepository<Society, Guid> 
    {
         Task<Society> GetAsync(Guid id);
        Task<List<Building>> GetBuildingsInSocietyAsync(Guid societyId);
        Task<Building> GetBuildingInSocietyAsync(Guid societyId, Guid buildingId);
        Task<List<Flat>> GetFlatsInSocietyBuildingAsync(Guid societyId, Guid buildingId);
        
    }
}
