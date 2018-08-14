﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Core.Interface
{
    public interface IRepository<T,U>
        where T:class,IIdentifiableModel<U>
    {
        
        U Add(T newEntity);
        
        void Remove(T entity);
        void Remove(U id);
        T Get(U id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        bool Save();

    }
}