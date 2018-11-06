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
        Task<IdentityResult> CreateUser(SupportUser user);

        ApolloUser GetById(Guid id);
    }
}
