using Store.Application.Mappers;
using Store.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Store.Application.Products.Responses;
using Store.Core.Entities;
using Store.Core.Common.Exceptions;

namespace Store.Application.Products.Commands
{
    public class ProductCommanHandler : IRequestHandler<ProductAddCommand, ProductResponse>,
                                        IRequestHandler<ProductUpdateCommand, ProductResponse>,
                                        IRequestHandler<ProductDeleteCommand, bool>
    {
        private readonly IProductRepository _ProductRepo;
        public ProductCommanHandler(IProductRepository ProductRepository)
        {
            _ProductRepo = ProductRepository;
        }

        // Add
        public async Task<ProductResponse> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ProductEntitiy = StoreMapper.Mapper.Map<Product>(request);
                if (ProductEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var newProduct = await _ProductRepo.AddAsync(ProductEntitiy);
                var ProductResponse = StoreMapper.Mapper.Map<ProductResponse>(newProduct);
                return ProductResponse;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("unique index"))
                    throw new EntityIsAlreadyExists(nameof(Product));
                else
                    throw ex;
            }
        }

        // Update 
        public async Task<ProductResponse> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var ProductEntitiy = StoreMapper.Mapper.Map<Product>(request);
            if (ProductEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var UpdatedProduct = await _ProductRepo.UpdateAsync(ProductEntitiy.Id, ProductEntitiy);
            var ProductResponse = StoreMapper.Mapper.Map<ProductResponse>(UpdatedProduct);
            return ProductResponse;
        }

        // Delete
        public async Task<bool> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _ProductRepo.GetByIdAsync(request.Id);
                if (product is null)
                {
                    throw new NotFoundException(nameof(Product));
                }
                await _ProductRepo.DeleteAsync(product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
