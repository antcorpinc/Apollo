using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.Common.Mappers
{
    public static class CommonMapper
    {
        public static List<Domain.DTO.MasterData.State> MaptoState(
            List<Domain.Entity.MasterData.State> fromStates)
        {
            return Mapper.Map<List<Domain.DTO.MasterData.State>>(fromStates);
        }
    }
}
