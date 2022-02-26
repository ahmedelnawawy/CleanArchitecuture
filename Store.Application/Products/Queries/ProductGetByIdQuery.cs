using MediatR;
using Store.Application.Products.Responses;
using System;

namespace Store.Application.Products.Queries
{
    public class ProductGetByIdQuery : IRequest<ProductResponse>
    {
        public Int64 Id { get; set; }
    }
}
