using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Data.DataRepository
{
    public class UserAppRoleMappingRepository : IUserAppRoleMappingRepository
    {
        private readonly ApolloContext _context;
        public UserAppRoleMappingRepository(ApolloContext context)
        {
            _context = context;
        }
        public Guid Add(UserAppRoleMapping newEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserAppRoleMapping> Find(Expression<Func<UserAppRoleMapping, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public UserAppRoleMapping Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserAppRoleMapping entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(UserAppRoleMapping[] items)
        {
            _context.RemoveRange(items);
            bool result = Save();

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
