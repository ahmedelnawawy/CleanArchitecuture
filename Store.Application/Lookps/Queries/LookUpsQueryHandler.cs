using MediatR;
using Store.Application.Mappers;
using Store.Application.SharedModels;
using Store.Core.Common.Exceptions;
using Store.Core.Entities;
using Store.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Lookps.Queries
{
    public class LookUpsQueryHandler : IRequestHandler<QuantityPerUnitListQuery, List<QuantityPerUnitViewModel>>
    {
        private readonly IQuantityPerUnitRepository _QuantityPerUnitRepo;
        public LookUpsQueryHandler(IQuantityPerUnitRepository QuantityPerUnitRepository)
        {
            _QuantityPerUnitRepo = QuantityPerUnitRepository;
        }
        public async Task<List<QuantityPerUnitViewModel>> Handle(QuantityPerUnitListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var quantityPerUnits = await _QuantityPerUnitRepo.GetAllAsync();
                if (quantityPerUnits == null)
                    throw new NotFoundException(nameof(QuantityPerUnit));
                return StoreMapper.Mapper.Map<List<QuantityPerUnitViewModel>>(quantityPerUnits);
            }
            catch (Exception Exe)
            {
                throw new NotFoundException(nameof(Product));
            }
        }
    }
}
