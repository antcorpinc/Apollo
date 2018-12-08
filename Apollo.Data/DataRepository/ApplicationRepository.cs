using Apollo.Core.Interface;
using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class ApplicationRepository : IApplicationRepository, IDisposable
    {
        private  ApolloContext _context;

        public ApplicationRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Guid Add(Application newEntity)
        {
            throw new NotImplementedException();
        }

        public List<Application> Find(Expression<Func<Application, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Application>> FindAsync(Expression<Func<Application, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Application Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Application> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<List<Application>> GetAllAsync()
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
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public Task<Application> AddAsync(Application newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
