using MediatR;
using Store.Application.Suppliers.Responses;
using System.Collections.Generic;

namespace Store.Application.Suppliers.Queries
{
    public class SupplierListQuery : IRequest<List<SupplierResponse>>
    {
    }
}
