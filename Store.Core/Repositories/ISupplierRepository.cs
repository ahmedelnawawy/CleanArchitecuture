using Store.Core.Entities;
using Store.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        //custom operations here
        Task<Tuple<Supplier, int>> GetLargestSupplier();
    }
}
