using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Data.DataRepository
{
    public class UserRepository : IUserRepository
    {
        public Guid Add(ApolloUser newEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApolloUser> Find(Expression<Func<ApolloUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ApolloUser Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ApolloUser entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
