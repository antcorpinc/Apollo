using Apollo.Data.Interface;
using Apollo.Domain.DTO.MasterData;
using Apollo.Service.Common.Interface;
using Apollo.Service.Common.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.Common
{
    public class StateService : IStateService
    {
        private IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository ??
                throw new ArgumentNullException(nameof(stateRepository));
        }
        public List<State> GetAll()
        {
            var states = this._stateRepository.GetAll();
            if (states != null && states.Count() > 0)
            {
                return AutoMapper.Mapper.Map<IEnumerable<State>>(states).ToList();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<State>> GetAllAsync()
        {
            var states = await this._stateRepository.GetAllAsync();

            return CommonMapper.MaptoState(states);
        }

        public async Task<List<Area>> GetAreasForCityStateAsync(int stateId, int cityId)
        {
            var areas = await this._stateRepository.GetAreasForCityState(stateId, cityId);
            return CommonMapper.MaptoArea(areas);
        }

        public async Task<List<City>> GetCitiesForStateAsync(int stateId)
        {
            var cities = await this._stateRepository.GetCitiesForState(stateId);
            return CommonMapper.MaptoCity(cities);
        }
    }
}
