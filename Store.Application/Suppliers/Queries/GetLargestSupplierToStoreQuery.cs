using MediatR;
using Store.Application.Suppliers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Suppliers.Queries
{
    public class GetLargestSupplierToStoreQuery : IRequest<LargestSupplierResponse>
    {
    }
}
