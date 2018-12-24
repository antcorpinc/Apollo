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
    public class SocietyRepository : ISocietyRepository, IDisposable
    {
        private  ApolloContext _context;
        public SocietyRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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

        public async Task<List<Society>> GetAllAsync()
        {
            return await _context.Society
                   .Include(s => s.Area)
                   .Include(s => s.City)
                   .Include(s => s.State).ToListAsync();
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

        public async Task<Society> AddAsync(Society newEntity)
        {
            _context.Society.Attach(newEntity); // Do we need this?
            _context.ApplyStateChanges();
            await _context.SaveChangesAsync();
            return newEntity;           
        }

        public  async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<Society> GetAsync(Guid id)
        {
            return await _context.Society.Where(soc => soc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Society> UpdateAsync(Society updatedEntity)
        {
            _context.Society.Attach(updatedEntity); // Do we need this?
            _context.ApplyStateChanges();
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await _context.Society.AnyAsync(s => s.Id == id);
        }
    }
}
