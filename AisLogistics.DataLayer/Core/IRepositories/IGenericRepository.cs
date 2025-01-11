using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IQueryable<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
