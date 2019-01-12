using Apollo.Core.Common;
using Apollo.Domain.DTO;
using Apollo.Domain.DTO.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.SocietyManagement.Interface
{
    public interface ISocietyService
    {
        List<SocietyList> GetAll();
        Task<List<Domain.DTO.SocietyList>> GetAllAsync();
        Task<ServiceResponse<Society>>CreateSociety(Society society);
        Task<ServiceResponse<Society>> UpdateAsync(Society society);
        Task<ServiceResponse<Society>> GetAsync(Guid id);

        Task<bool> IsExistsAsync(Guid id);
        Task<bool> IsBuildingExistsAsync(Guid societyId, Guid buildingId);
        Task<ServiceResponse<List<Domain.DTO.Society.Building>>> GetBuildingsInSocietyAsync(Guid societyId);
        Task<ServiceResponse<Building>> GetBuildingInSocietyAsync(Guid societyId, Guid buildingId);
        Task<ServiceResponse<List<Flat>>> GetFlatsInSocietyBuildingAsync(Guid societyId, Guid buildingId);
        Task<ServiceResponse<Flat>> GetFlatInSocietyBuildingAsync
            (Guid societyId, Guid buildingId, Guid flatId);
        Task<ServiceResponse<List<SocietyListItem>>> GetSocietiesWithCustomSearchAsync(string customSearch);
    }
}
