using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Data.DataRepository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApolloContext _context;

        public ApplicationRepository(ApolloContext context)
        {
            _context = context;
        }
        public Guid Add(Application newEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Application> Find(Expression<Func<Application, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Application Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Application> GetApplications()
        {
            return _context.Application.ToList();

        }

        public void Remove(Application entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
