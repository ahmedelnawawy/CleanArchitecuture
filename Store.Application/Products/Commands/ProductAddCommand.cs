using MediatR;
using Store.Application.Enums;
using Store.Application.Products.Responses;

namespace Store.Application.Products.Commands
{
    public class ProductAddCommand : IRequest<ProductResponse>
    {
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public QuantityPerUnitEnum QuantityPerUnitId { get; set; }
        public int SupplierId { get; set; }
    }
}
