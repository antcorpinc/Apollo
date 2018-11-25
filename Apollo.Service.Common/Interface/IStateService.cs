using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.Common.Interface
{
    public interface IStateService
    {
        List<Apollo.Domain.DTO.MasterData.State> GetAll();
        Task<List<Domain.DTO.MasterData.State>> GetAllAsync();

        Task<List<Domain.DTO.MasterData.City>> GetCitiesForStateAsync(int stateId);
        Task<List<Domain.DTO.MasterData.Area>> GetAreasForCityStateAsync(int stateId, int cityId);
    }
}
