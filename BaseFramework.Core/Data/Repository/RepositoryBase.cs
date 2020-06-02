using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Core.Data.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        public RepositoryBase(DbContext _context)
        {
            context = _context;
        }
        public T Add(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            var dbSet = context.Set<T>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return GetQueryable(filter, null, null).SingleOrDefault();
        }

        protected virtual IQueryable<T> GetQueryable(
                                     Expression<Func<T, bool>> filter = null,
                                     Expression<Func<T, object>> include = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     int? skip = null,
                                     int? take = null)
        {
            IQueryable<T> query = context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include.Name);
            }
            return query;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> include = null)
        {
            return GetQueryable(filter, include, null);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, include, orderBy, skip, take);
        }

        public virtual int Count(Expression<Func<T, bool>> filter = null)
        {
            return GetQueryable(filter).Count();
        }

        public IQueryable<T> GetAll()
        {
            return Get(null, null, null, null);
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public T GetIncludes(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = GetQueryable(filter, null, null);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault();
        }
    }
}
