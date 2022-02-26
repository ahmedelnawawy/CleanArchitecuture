using Store.Application.Mappers;
using Store.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Store.Application.Suppliers.Responses;
using Store.Core.Entities;
using Store.Core.Common.Exceptions;

namespace Store.Application.Suppliers.Commands
{
    public class SupplierCommanHandler : IRequestHandler<SupplierAddCommand, SupplierResponse>,
                                        IRequestHandler<SupplierUpdateCommand, SupplierResponse>,
                                        IRequestHandler<SupplierDeleteCommand, bool>
    {
        private readonly ISupplierRepository _SupplierRepo;
        private readonly IProductRepository _ProductRepo;
        public SupplierCommanHandler(ISupplierRepository SupplierRepository, IProductRepository ProductRepository)
        {
            _SupplierRepo = SupplierRepository;
            _ProductRepo = ProductRepository;
        }

        // Add
        public async Task<SupplierResponse> Handle(SupplierAddCommand request, CancellationToken cancellationToken)
        {
            var SupplierEntitiy = StoreMapper.Mapper.Map<Supplier>(request);
            if (SupplierEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newSupplier = await _SupplierRepo.AddAsync(SupplierEntitiy);
            var SupplierResponse = StoreMapper.Mapper.Map<SupplierResponse>(newSupplier);
            return SupplierResponse;
        }

        // Update 
        public async Task<SupplierResponse> Handle(SupplierUpdateCommand request, CancellationToken cancellationToken)
        {
            var SupplierEntitiy = StoreMapper.Mapper.Map<Supplier>(request);
            if (SupplierEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var UpdatedSupplier =await _SupplierRepo.UpdateAsync(SupplierEntitiy.Id,SupplierEntitiy);
            var SupplierResponse = StoreMapper.Mapper.Map<SupplierResponse>(UpdatedSupplier);
            return SupplierResponse;
        }

        // Delete
        public async Task<bool> Handle(SupplierDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Supplier = await _SupplierRepo.GetByIdAsync(request.Id);
                if (Supplier is null)
                    throw new NotFoundException(nameof(Supplier));
                var IsUsedInProduct = await _ProductRepo.IsSupplierAddProducts(request.Id);
                if (IsUsedInProduct)
                    throw new DependencyViolationException(nameof(Product), nameof(Supplier));
                await _SupplierRepo.DeleteAsync(Supplier);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
