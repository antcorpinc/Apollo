using Apollo.Data.Interface;
using Apollo.Domain.DTO.MasterData;
using Apollo.Service.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Service.Common
{
    public class StateService : IStateService
    {
        private IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
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
    }
}
