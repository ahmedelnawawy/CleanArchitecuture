using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsyncWithInclude(string expression);
        Task<T> GetByIdAsync(Int64 id);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id , T entity);
        Task<T> UpdateAsync(Int64 id , T entity);
        Task DeleteAsync(T entity);
    }
}
