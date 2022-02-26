using AutoMapper;
using Store.Application.SharedModels;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Lookps.MappProfile
{
    public class LookupsMappingProfile : Profile
    {
        public LookupsMappingProfile()
        {
            CreateMap<QuantityPerUnit, QuantityPerUnitViewModel>().ReverseMap();
        }
    }
}
