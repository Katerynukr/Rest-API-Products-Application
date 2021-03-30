using AutoMapper;
using RestAPIApplication.Dtos;
using RestAPIApplication.Models;
using RestAPIApplication.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Vegetables>().ReverseMap();
            CreateMap<ProductDto, Fruits>().ReverseMap();
            CreateMap<ProductDto, DieryProducts>().ReverseMap();
            CreateMap<ProductDto, MeatProducts>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductDto, BoughtProduct>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
        }
    }
}
