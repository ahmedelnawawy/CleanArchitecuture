using MediatR;
using Store.Application.Mappers;
using Store.Application.Products.Responses;
using Store.Core.Common.Exceptions;
using Store.Core.Entities;
using Store.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Products.Queries
{
    public class ProductQueryHandler : IRequestHandler<ProductListQuery, List<ProductResponse>>,
                                       IRequestHandler<ProductGetByIdQuery, ProductResponse>,
                                       IRequestHandler<ProductSearchQuery, List<ProductResponse>>,
                                       IRequestHandler<GetProductNeedReOrderQuery, List<ProductResponse>>
    {
        private readonly IProductRepository _ProductRepo;
        public ProductQueryHandler(IProductRepository ProductRepository)
        {
            _ProductRepo = ProductRepository;
        }

        public async Task<List<ProductResponse>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Name Of Entities Which need Load
                string expression = "QuantityPerUnit;Supplier";
                var products = await _ProductRepo.GetAllAsyncWithInclude(expression);

                if (products == null)
                    throw new NotFoundException(nameof(Product));

                return StoreMapper.Mapper.Map<List<ProductResponse>>(products);
            }
            catch (Exception Exe)
            {
                throw new NotFoundException(nameof(Product));
            }
        }

        public async Task<ProductResponse> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _ProductRepo.GetProductByIdWithEagerLoading(request.Id);
                if (product == null)
                    throw new NotFoundException(nameof(Product));

                return StoreMapper.Mapper.Map<ProductResponse>(product);
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(Product));
            }
        }

        public async Task<List<ProductResponse>> Handle(ProductSearchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var ProductFilter = StoreMapper.Mapper.Map<Product>(request);
                var product = await _ProductRepo.GetProductByFilter(ProductFilter);
                if (product == null)
                    throw new NotFoundException(nameof(Product));

                return StoreMapper.Mapper.Map<List<ProductResponse>>(product);
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(Product));
            }
        }

        public async Task<List<ProductResponse>> Handle(GetProductNeedReOrderQuery request, CancellationToken cancellationToken)
        {
            var product = await _ProductRepo.GetProductNeedReOrder();
            if (product == null)
                throw new NotFoundException(nameof(Product));

            return StoreMapper.Mapper.Map<List<ProductResponse>>(product);
        }
    }
}
