using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DddDotNetCore.Repository
{
    /* by Macoratti Reference */
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
