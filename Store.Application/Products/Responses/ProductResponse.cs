using Store.Application.SharedModels;
using System;

namespace Store.Application.Products.Responses
{
    public class ProductResponse
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }

        public int QuantityPerUnitId { get; set; }
        public QuantityPerUnitViewModel QuantityPerUnit { get; set; }
        //
        public int SupplierId { get; set; }
        public SupplierViewModel Supplier { get; set; }
    }
}
