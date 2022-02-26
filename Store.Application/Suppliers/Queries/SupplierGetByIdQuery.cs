using MediatR;
using Store.Application.Suppliers.Responses;
using System;

namespace Store.Application.Suppliers.Queries
{
    public class SupplierGetByIdQuery : IRequest<SupplierResponse>
    {
        public int Id { get; set; }
    }
}
