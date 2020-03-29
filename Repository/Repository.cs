using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DddDotNetCore.Repository
{
    /* by Macoratti Reference */
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.Set<T>().Update(entity);
        }

        public IEnumerable<T> Get()
        {
            var collection = context.Set<T>().AsEnumerable<T>();
            return collection.ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            var collection = context.Set<T>().Where(predicate).AsEnumerable<T>();
            return collection.ToList();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().SingleOrDefault(predicate);
        }
    }
}
