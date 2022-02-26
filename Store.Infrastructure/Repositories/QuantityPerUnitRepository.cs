using Store.Core.Entities;
using Store.Core.Repositories;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Infrastructure.Repositories
{
    public class QuantityPerUnitRepository : Repository<QuantityPerUnit>, IQuantityPerUnitRepository
    {
        public QuantityPerUnitRepository(StoreContext StoreContext) : base(StoreContext) { }
    }
}
