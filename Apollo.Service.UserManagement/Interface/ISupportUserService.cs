using Apollo.Domain.Entity;
using Apollo.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement.Interface
{
    public interface ISupportUserService
    {
        List<ApolloUser> GetAllUsers();
        // Task<List<ApolloUser>> GetAllUsersAsync();
        Task<List<Domain.DTO.SupportUserList>> GetAllUsersAsync();

        Task<IdentityResult> CreateUser(SupportUser user);

        ApolloUser GetById(Guid id);
        Task<ApolloUser> GetByIdAsync(Guid id);

         Task<IdentityResult> UpdateUser(SupportUser user );
    }
}
