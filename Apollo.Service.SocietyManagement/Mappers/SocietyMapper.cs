using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.SocietyManagement.Mappers
{
    public static class SocietyMapper
    {
        public static List<Apollo.Domain.DTO.SocietyList> MapToSocietyList(List
            <Domain.Entity.Society.Society> fromSocieties)
        {
            return Mapper.Map<List<Apollo.Domain.DTO.SocietyList>>(fromSocieties);
        }

        public static Apollo.Domain.Entity.Society.Society MapToSocietyEntity(
            Domain.DTO.Society.Society fromSocietyDTO)
        {
            return Mapper.Map<Apollo.Domain.Entity.Society.Society>(fromSocietyDTO);
        }
    }
}
