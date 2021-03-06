﻿using Apollo.Core.Interface;
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
    public class BuildingRepository : IBuildingRepository, IDisposable
    {
        private ApolloContext _context;
        public BuildingRepository(ApolloContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Guid Add(Building newEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<Building> AddAsync(Building newEntity)
        {
            _context.Building.Attach(newEntity); // Do we need this?
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
        public List<Domain.Entity.Society.Building> Find(Expression<Func<Domain.Entity.Society.Building, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entity.Society.Building>> FindAsync(Expression<Func<Domain.Entity.Society.Building, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.Society.Building Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entity.Society.Building> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entity.Society.Building>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entity.Society.Building entity)
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

        public async Task<Building> UpdateAsync(Building updatedEntity)
        {
            _context.Building.Attach(updatedEntity); // Do we need this?
            _context.ApplyStateChanges();
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task<bool> IsBuildingInSocietyExistsAsync(Guid societyId, Guid buildingId)
        {
            return await _context.Building.AnyAsync(b =>
                         b.SocietyId == societyId && b.Id == buildingId);
        }
    }
}
