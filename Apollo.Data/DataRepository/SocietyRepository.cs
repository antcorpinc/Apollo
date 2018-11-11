using Apollo.Data.Interface;
using Apollo.Domain.Entity.Society;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class SocietyRepository : ISocietyRepository
    {
        private readonly ApolloContext _context;
        public SocietyRepository(ApolloContext context)
        {
            _context = context;
        }
        public Guid Add(Society newEntity)
        {
            throw new NotImplementedException();
        }

        public List<Society> Find(Expression<Func<Society, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Society>> FindAsync(Expression<Func<Society, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        
        public Society Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Society> GetAll()
        {
            return _context.Society
                    .Include(s => s.Area)
                    .Include(s => s.City)
                    .Include(s => s.State);                
        }
        public void Remove(Society entity)
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
