using AutoMapper;
using Store.Application.Suppliers.Commands;
using Store.Application.Suppliers.Responses;
using Store.Core.Entities;

namespace Store.Application.Suppliers.MappProfile
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierResponse>().ReverseMap();
            CreateMap<Supplier, LargestSupplierResponse>().ReverseMap();
            CreateMap<Supplier, SupplierAddCommand>().ReverseMap();
            CreateMap<Supplier, SupplierUpdateCommand>().ReverseMap();
        }
    }
}
