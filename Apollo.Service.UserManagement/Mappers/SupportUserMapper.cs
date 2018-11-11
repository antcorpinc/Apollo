using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.UserManagement.Mappers
{
    public static class SupportUserMapper
    {
        public static List<Apollo.Domain.DTO.SupportUserList> MapSupportUserList(List<Domain.Entity.ApolloUser> fromEntity)
        {
            return Mapper.Map<List<Apollo.Domain.DTO.SupportUserList>>(fromEntity);
        }
    }
}
