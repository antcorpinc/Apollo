using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApolloContext _context;
        private readonly UserManager<ApolloUser> _userManager;
        public UserRepository(ApolloContext context, UserManager<ApolloUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public Guid Add(ApolloUser newEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> Add(ApolloUser user, string password)
        {
            return await _userManager.CreateAsync(user, password).ConfigureAwait(false); ;
        }

        public IQueryable<ApolloUser> Find(Expression<Func<ApolloUser, bool>> predicate)
        {
            return _context.User.Where(predicate);
        }

        public ApolloUser Get(Guid id)
        {
            return _context.User.Where(users => users.Id == id)
                .Include(user => user.UserAppRoleMapping)
                .FirstOrDefault();
        }

        public void Remove(ApolloUser entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> Update(ApolloUser user)
        {
            return await _userManager.UpdateAsync(user).ConfigureAwait(false);
        }
    }
}
