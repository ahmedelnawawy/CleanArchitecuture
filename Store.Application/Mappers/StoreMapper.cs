using AutoMapper;
using Store.Application.Lookps.MappProfile;
using Store.Application.Products.MappProfile;
using Store.Application.Suppliers.MappProfile;
using System;

namespace Store.Application.Mappers
{
    public class StoreMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ProductMappingProfile>();
                cfg.AddProfile<SupplierMappingProfile>();
                cfg.AddProfile<LookupsMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
