using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Repositories;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        //custom operations here
        public SupplierRepository(StoreContext StoreContext) : base(StoreContext) { }

        public async Task<Tuple<Supplier,int>> GetLargestSupplier()
        {
            var MaxSupplier = await _StoreContext.Products.Include(x=>x.Supplier).GroupBy(c => c.SupplierId)
             .Select(g => new
             {
                 SupplierId = g.Key,
                 count = g.Count(),
             })
             .OrderByDescending(c => c.count).FirstOrDefaultAsync();
            return Tuple.Create(await _StoreContext.Suppliers.FirstOrDefaultAsync(x => x.Id == MaxSupplier.SupplierId)
                , MaxSupplier.count);
        }
    }
}
