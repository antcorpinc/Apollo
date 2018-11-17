using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.SocietyManagement.Mappers
{
    public static class SocietyMapper
    {
        public static List<Apollo.Domain.DTO.SocietyList> MapToSociety(List
            <Domain.Entity.Society.Society> fromSocieties)
        {
            return Mapper.Map<List<Apollo.Domain.DTO.SocietyList>>(fromSocieties);
        }
    }
}
