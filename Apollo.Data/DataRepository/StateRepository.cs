using Apollo.Data.Interface;
using Apollo.Domain.Entity.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class StateRepository : IStateRepository
    {
        private readonly ApolloContext _context;
        public StateRepository(ApolloContext context)
        {
             _context = context;
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
    }
}
