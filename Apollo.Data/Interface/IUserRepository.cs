using Apollo.Core.Interface;
using Apollo.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface IUserRepository : IRepository<ApolloUser, Guid>   {

        // Add User Specific Methods
        Task<IdentityResult> Add(ApolloUser user, string password);

         Task<IdentityResult> Update(ApolloUser user);
        //ApolloUser Update(ApolloUser user);

        List<ApolloUser> FindSupportUsers(Expression<Func<ApolloUser, bool>> predicate);
        Task<List<ApolloUser>> FindSupportUsersAsync(Expression<Func<ApolloUser, bool>> predicate);

       // List<ApolloUser> GetSupportUsers();

       // Task<List<ApolloUser>> GetSupportUsersAsync();

        Task<ApolloUser> FindById(Guid id);

        Task<ApolloUser> GetAsync(Guid id);

       
    }
}