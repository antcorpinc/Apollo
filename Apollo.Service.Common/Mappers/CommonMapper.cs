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

        public static List<Domain.DTO.MasterData.City> MaptoCity(
            List<Domain.Entity.MasterData.City> fromCities)
        {
            return Mapper.Map<List<Domain.DTO.MasterData.City>>(fromCities);
        }

        public static List<Domain.DTO.MasterData.Area> MaptoArea(
            List<Domain.Entity.MasterData.Area> fromCityStates)
        {
            return Mapper.Map<List<Domain.DTO.MasterData.Area>>(fromCityStates);
        }
    }
}
