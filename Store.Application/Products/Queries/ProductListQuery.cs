using MediatR;
using Store.Application.Products.Responses;
using System.Collections.Generic;

namespace Store.Application.Products.Queries
{
    public class ProductListQuery : IRequest<List<ProductResponse>>
    {
    }
}
