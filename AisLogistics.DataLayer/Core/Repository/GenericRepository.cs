using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AisLogistics.DataLayer.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AisLogisticsContext _context;
        internal readonly ILogger _logger;
        internal readonly DbSet<T> DbSet;

        public GenericRepository(AisLogisticsContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            DbSet = context.Set<T>();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await DbSet.AddAsync(entity);
            return true;
        }
        
        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<T>> All()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
