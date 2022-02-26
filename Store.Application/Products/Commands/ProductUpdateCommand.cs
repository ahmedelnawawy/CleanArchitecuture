using MediatR;
using Store.Application.Enums;
using Store.Application.Products.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Commands
{
    public class ProductUpdateCommand : IRequest<ProductResponse>
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public QuantityPerUnitEnum QuantityPerUnitId { get; set; }
        public int SupplierId { get; set; }
    }
}
