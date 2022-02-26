using MediatR;
using Store.Application.Suppliers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Suppliers.Commands
{
    public class SupplierUpdateCommand : IRequest<SupplierResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
