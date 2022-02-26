using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Commands
{
    public class ProductDeleteCommand : IRequest<bool>
    {
        public Int64 Id { get; set; }
    }
}
