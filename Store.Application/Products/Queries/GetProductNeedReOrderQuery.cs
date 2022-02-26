using MediatR;
using Store.Application.Products.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Queries
{
    public class GetProductNeedReOrderQuery : IRequest<List<ProductResponse>>
    {
    }
}
