using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.BackOffice.MappingConfig
{
    public class BackOfficeMgmtMappingProfile : Profile
    {
        public BackOfficeMgmtMappingProfile()
        {
            CreateMap<Domain.Entity.MasterData.State, Domain.DTO.MasterData.State>()
                .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Name)).ReverseMap();
        }
    }
}
