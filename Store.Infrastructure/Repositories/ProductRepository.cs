using Store.Core.Entities;
using Store.Core.Repositories;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext StoreContext) : base(StoreContext) { }

        public async Task<IEnumerable<Product>> GetProductNeedReOrder()
        {
            return await _StoreContext.Products.AsNoTracking()
                .Where(m => m.UnitsInStock <= m.ReorderLevel).ToListAsync();
        }
        public async Task<Product> GetProductByIdWithEagerLoading(Int64 Id)
        {
            return await _StoreContext.Products.AsNoTracking()
                .Include(item => item.Supplier)
                .Include(item => item.QuantityPerUnit)
                .FirstOrDefaultAsync(m => m.Id == Id);
        }
        public async Task<IEnumerable<Product>> GetProductByFilter(Product filter)
        {
            return await _StoreContext.Products.AsNoTracking().
                Where(x =>
                (filter.Id == 0 || x.Id == filter.Id) &&
                (string.IsNullOrEmpty(filter.Name) || x.Name == filter.Name) &&
                (filter.QuantityPerUnitId == 0 || x.QuantityPerUnitId == filter.QuantityPerUnitId) &&
                (filter.ReorderLevel == 0 || x.ReorderLevel == filter.ReorderLevel) &&
                (filter.SupplierId == 0 || x.SupplierId == filter.SupplierId) &&
                (filter.UnitPrice == 0 || x.UnitPrice == filter.UnitPrice) &&
                (filter.UnitsInStock == 0 || x.UnitsInStock == filter.UnitsInStock) &&
                (filter.UnitsOnOrder == 0 || x.UnitsOnOrder == filter.UnitsOnOrder)
                )
                .Include(item => item.Supplier)
                .Include(item => item.QuantityPerUnit)
                .ToListAsync();
        }
        public async Task<bool> IsSupplierAddProducts(int SupplierId)
        {
            return await _StoreContext.Products.AsNoTracking().
                Where(x => x.SupplierId == SupplierId).AnyAsync();
        }

    }
}
