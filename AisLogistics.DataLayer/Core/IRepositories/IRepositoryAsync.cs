using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Core.IRepositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Entities { get; }
    }
}
