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
            CreateMap<ProductDto, Vegetable>().ReverseMap();
            CreateMap<ProductDto, Fruit>().ReverseMap();
            CreateMap<ProductDto, DairyProduct>().ReverseMap();
            CreateMap<ProductDto, MeatProduct>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductDto, BoughtProduct>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
        }
    }
}
