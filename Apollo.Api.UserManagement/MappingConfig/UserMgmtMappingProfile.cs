using Apollo.Domain.DTO;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.UserManagement.MappingConfig
{
    public class UserMgmtMappingProfile: Profile
    {
        public UserMgmtMappingProfile()
        {
            CreateMap<ApolloUser, SupportUserList>()
                .ForMember(des => des.UserApplicationRole,
                opt => opt.MapFrom(s => s.UserAppRoleMappings)).ReverseMap();

            CreateMap<ApolloUser, SupportUser>()
            .ForMember(des => des.UserApplicationRole,
            opt => opt.MapFrom(s => s.UserAppRoleMappings)).ReverseMap();

            CreateMap<Domain.Entity.Application, Domain.DTO.Application>();

            CreateMap<Domain.Entity.ApplicationRole, Role>()
               .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Role.Id))
               .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Role.Name))
               .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.Role.IsActive))
               .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Role.Description));

            CreateMap<Domain.Entity.Society.Society, SocietyList>()
                .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.Area, opt => opt.MapFrom(s => s.Area.Name))
                .ForMember(des => des.City, opt => opt.MapFrom(s => s.City.Name))
                .ForMember(des => des.State, opt => opt.MapFrom(s => s.State.Name))
                .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(s => s.UpdatedBy))
                .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate));

            CreateMap<Domain.Entity.MasterData.State, Domain.DTO.MasterData.State>()
            .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Name));

        }
    }
}
