using MediatR;
using Store.Application.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Lookps.Queries
{
    public class QuantityPerUnitListQuery : IRequest<List<QuantityPerUnitViewModel>>
    {
    }
}
