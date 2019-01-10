using Apollo.Core.Common;
using Apollo.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement.Interface
{
    public interface ISocietyUserService
    {
        List<ApolloUser> GetAllUsers();

        Task<ServiceResponse<Apollo.Domain.DTO.SocietyUser>> CreateUserAsync(Apollo.Domain.DTO.SocietyUserCreate user);
    }
}
