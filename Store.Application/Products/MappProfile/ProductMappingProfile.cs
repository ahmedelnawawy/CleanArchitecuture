using AutoMapper;
using Store.Application.SharedModels;
using Store.Application.Products.Commands;
using Store.Application.Products.Responses;
using Store.Core.Entities;
using Store.Application.Products.Queries;

namespace Store.Application.Products.MappProfile
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, ProductAddCommand>().ReverseMap();
            CreateMap<Product, ProductUpdateCommand>().ReverseMap();
            CreateMap<Product, ProductSearchQuery>().ReverseMap();
            
        }
    }
}
