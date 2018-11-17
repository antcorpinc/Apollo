using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.Society.MappingConfig
{
    public class SocietyMappingProfile: Profile
    {
        public SocietyMappingProfile()
        {
            CreateMap<Domain.Entity.Society.Society, Apollo.Domain.DTO.SocietyList>()
                .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.Area, opt => opt.MapFrom(s => s.Area.Name))
                .ForMember(des => des.City, opt => opt.MapFrom(s => s.City.Name))
                .ForMember(des => des.State, opt => opt.MapFrom(s => s.State.Name))
                .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive));
        }
    }
}
