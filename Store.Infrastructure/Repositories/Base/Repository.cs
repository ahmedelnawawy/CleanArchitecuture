using Store.Core.Repositories.Base;
using Store.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace Store.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly StoreContext _StoreContext;
        protected readonly DbSet<T> _dbSet;
        public Repository(StoreContext StoreContext)
        {
            _StoreContext = StoreContext;
            _dbSet = _StoreContext.Set<T>();
        }


        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _StoreContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _StoreContext.SaveChangesAsync();
        }

        #region Get
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsyncWithInclude(string expression)
        {
            var includes = expression.Split(';');
            var query = _dbSet.AsQueryable();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        #endregion

        #region Update
        public async Task<T> UpdateAsync(int id, T entity)
        {
            var obj = await GetByIdAsync(id);
            _StoreContext.Entry(obj).CurrentValues.SetValues(entity);
            await _StoreContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(Int64 id, T entity)
        {
            var obj = await GetByIdAsync(id);
            _StoreContext.Entry(obj).CurrentValues.SetValues(entity);
            await _StoreContext.SaveChangesAsync();
            return entity;
        }
        #endregion
    }
}
