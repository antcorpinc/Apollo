using Apollo.Data.Interface;
using Apollo.Domain.Entity.MasterData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class StateRepository : IStateRepository, IDisposable
    {
        private  ApolloContext _context;
        public StateRepository(ApolloContext context)
        {
             _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public int Add(State newEntity)
        {
            throw new NotImplementedException();
        }

        public List<State> Find(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<State>> FindAsync(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }      
        public State Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<State> GetAll()
        {
            return _context.State;
        }
        public async Task<List<State>> GetAllAsync()
        {
            return await _context.State.ToListAsync();
        }
        public void Remove(State entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
        public async Task<List<City>> GetCitiesForState(int stateId)
        {
            return await _context.City.Where(city => city.StateId == stateId).ToListAsync();
        }
        public async Task<List<Area>> GetAreasForCityState(int stateId, int cityId)
        {
            return await _context.Area.Where(area=> (area.StateId == stateId) 
            && area.CityId == cityId ).ToListAsync();
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

        
    }
}
