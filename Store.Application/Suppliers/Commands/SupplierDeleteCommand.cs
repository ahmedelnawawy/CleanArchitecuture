using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Suppliers.Commands
{
    public class SupplierDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
