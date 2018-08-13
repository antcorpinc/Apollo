using Apollo.Core.Interface;
using Apollo.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface IUserRepository : IRepository<ApolloUser, Guid>   {

        // Add User Specific Methods
        Task<IdentityResult> Add(ApolloUser user, string password);

        Task<IdentityResult> Update(ApolloUser user);
    }
}