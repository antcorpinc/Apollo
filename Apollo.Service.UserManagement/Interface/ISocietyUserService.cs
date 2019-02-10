using Apollo.Core.Common;
using Apollo.Domain.DTO.User;
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

        Task<ServiceResponse<Apollo.Domain.DTO.User.SocietyUser>> CreateUserAsync(Apollo.Domain.DTO.User.SocietyUserCreate user);

        Task<ServiceResponse<List<SocietyUserListItem>>> GetUsersForSocietyAsync(Guid societyId);
    }
}
