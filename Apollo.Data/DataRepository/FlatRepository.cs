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
    public class FlatRepository : IFlatRepository, IDisposable
    {
        private ApolloContext _context;
        public FlatRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Guid Add(Flat newEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<Flat> AddAsync(Flat newEntity)
        {
            _context.Flat.Attach(newEntity); // Do we need this?
            _context.ApplyStateChanges();
            await _context.SaveChangesAsync();
            return newEntity;
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

        public List<Flat> Find(Expression<Func<Flat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flat>> FindAsync(Expression<Func<Flat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Flat Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Flat> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Flat>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Flat entity)
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

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public Task<Flat> UpdateAsync(Flat updatedEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsFlatInInSocietyBuildingExistsAsync(Guid societyId, Guid buildingId, Guid flatId)
        {
             return await _context.Flat.AnyAsync(f =>
                         f.SocietyId == societyId &&  f.BuildingId == buildingId && f.Id == flatId);
        }
    }
}
