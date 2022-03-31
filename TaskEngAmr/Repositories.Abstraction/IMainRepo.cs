using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskEngAmr.Repositories.Abstraction
{
    public interface IMainRepo<T> where T : class
    {
        Task<IQueryable<T>> Get();
        Task<T> Get(int Id);
        Task<T> Add(T entity);
        Task<T> Edit(T entity);
        Task<T> Delete(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        Task SaveChanges();
    }
}
