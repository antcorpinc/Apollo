using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Core.Interface
{
    // Todo: Need to reafctor to add the GetAll and remove from other i/f's
    public interface IRepository<T,U>
        where T:class,IIdentifiableModel<U>
    {        
        U Add(T newEntity);
        
        void Remove(T entity);
        void Remove(U id);
        T Get(U id);
        List<T> Find(Expression<Func<T, bool>> predicate);

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync(); 
        bool Save();

    }
}
