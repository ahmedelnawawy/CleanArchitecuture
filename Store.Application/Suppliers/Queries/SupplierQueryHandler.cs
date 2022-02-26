using MediatR;
using Store.Application.Mappers;
using Store.Application.Suppliers.Responses;
using Store.Core.Common.Exceptions;
using Store.Core.Entities;
using Store.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Suppliers.Queries
{
    public class SupplierQueryHandler : IRequestHandler<SupplierListQuery, List<SupplierResponse>>,
                                        IRequestHandler<SupplierGetByIdQuery, SupplierResponse>,
                                        IRequestHandler<GetLargestSupplierToStoreQuery, LargestSupplierResponse>
    {
        private readonly ISupplierRepository _SupplierRepo;
        public SupplierQueryHandler(ISupplierRepository SupplierRepository)
        {
            _SupplierRepo = SupplierRepository;
        }

        public async Task<List<SupplierResponse>> Handle(SupplierListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Suppliers = await _SupplierRepo.GetAllAsync();
                if (Suppliers == null)
                    throw new NotFoundException(nameof(Supplier));

                return StoreMapper.Mapper.Map<List<SupplierResponse>>(Suppliers);
            }
            catch (Exception Exe)
            {
                throw new NotFoundException(nameof(Supplier));
            }
        }

        public async Task<SupplierResponse> Handle(SupplierGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Supplier = await _SupplierRepo.GetByIdAsync(request.Id);
                if (Supplier == null)
                    throw new NotFoundException(nameof(Supplier));

                return StoreMapper.Mapper.Map<SupplierResponse>(Supplier);
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(Supplier));
            }
        }

        public async Task<LargestSupplierResponse> Handle(GetLargestSupplierToStoreQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Supplier = await _SupplierRepo.GetLargestSupplier();
                if (Supplier == null)
                    throw new NotFoundException(nameof(Supplier));
                var res = StoreMapper.Mapper.Map<LargestSupplierResponse>(Supplier.Item1);
                res.Count = Supplier.Item2;
                return res ;
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(Supplier));
            }
        }
    }
}
