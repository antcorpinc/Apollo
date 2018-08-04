using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Core.Interface
{
    public interface IRepository<T,U>
        where T:class,IIdentifiableModel<U>
    {
        // May be the Add should return U which is the Id of the newly created Entity
        void Add(T newEntity);
        
        void Remove(T entity);
        void Remove(U id);
        T Get(U id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

    }
}
