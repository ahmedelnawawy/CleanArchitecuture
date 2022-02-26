using MediatR;
using Store.Application.Suppliers.Responses;

namespace Store.Application.Suppliers.Commands
{
    public class SupplierAddCommand : IRequest<SupplierResponse>
    {
        public string Name { get; set; }
    }
}
