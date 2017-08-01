using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VacationTracking.Data.Context;
using VacationTracking.Data.Common.Pagination;

namespace VacationTracking.Repository.Implementation
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly VacationContext _dbContext;

        public VacationContext GetContext()
        {
            return _dbContext;
        }
        protected IQueryable<T> Find(Func<IQueryable<T>, IQueryable<T>> filter = null)
        {
            if (filter == null)
                return _dbContext.Set<T>();
            return filter(_dbContext.Set<T>());
        }
        public virtual IPagedList<T> GetPage(int page = 1, int pageSize = 20, Func<IQueryable<T>, IQueryable<T>> filter = null)
        {
            return new PagedList<T>(Find(filter).AsNoTracking(), page, pageSize);
        }
        protected virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public RepositoryBase(VacationContext context)
        {
            _dbContext = context;
        }
        public virtual IEnumerable<T> Get(Func<IQueryable<T>, IQueryable<T>> filter = null)
        {
            return Find(filter).AsNoTracking().ToList();
        }

        public virtual void Add(T entity)
        {
            _dbContext.Add(entity);
            SaveChanges();
        }
        public virtual void Remove(T entity)
        {
            _dbContext.Remove(entity);
            SaveChanges();
        }
        public abstract void Edit(T entity);
        public abstract void Delete(int id);
    }
}
