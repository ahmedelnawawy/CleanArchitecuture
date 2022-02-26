using Store.Core.Entities;
using Store.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //custom operations here
        Task<IEnumerable<Product>> GetProductNeedReOrder();
        Task<Product> GetProductByIdWithEagerLoading(Int64 Id);
        Task<IEnumerable<Product>> GetProductByFilter(Product filter);
        Task<bool> IsSupplierAddProducts(int SupplierId);
    }
}
