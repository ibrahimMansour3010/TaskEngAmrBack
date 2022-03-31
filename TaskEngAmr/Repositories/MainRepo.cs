using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskEngAmr.Data.Access;
using TaskEngAmr.Repositories.Abstraction;

namespace TaskEngAmr.Repositories
{
    public class MainRepo<T> : IMainRepo<T> where T : class
    {
        private readonly TaskContext _context;
        private readonly DbSet<T> _dbSet;

        public MainRepo(TaskContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IQueryable<T>>Get()
        {
            return _dbSet.AsNoTracking();
        }
        public async Task<T>Get(int Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            _context.Entry<T>(entity).State = EntityState.Detached;
            if(entity == null)
                return null;
            return entity;
        }
        public async Task<T>Add(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }
        public async Task<T>Edit(T entity)
        {
            var result = _dbSet.Update(entity);
            return result.Entity;
        }
        public async Task<T>Delete(T entity)
        {
            var result = _dbSet.Remove(entity);
            return result.Entity;
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IIncludableQueryable<T, object> query = null;

            if (includes.Length > 0)
            {
                query = _dbSet.AsNoTracking().Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.AsNoTracking().Include(includes[queryIndex]);
            }

            return query == null ? _dbSet : (IQueryable<T>)query;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
