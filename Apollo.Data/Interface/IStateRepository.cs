using Apollo.Core.Interface;
using Apollo.Domain.Entity.MasterData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
   public interface IStateRepository:  IRepository<State, int>
    {
        Task<List<City>> GetCitiesForState(int stateId);
        Task<List<Area>> GetAreasForCityState(int stateId, int cityId);
    }
}
