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
            var map = CreateMap<BoughtProduct, ProductDto> ().ReverseMap();
            map.ForMember(dest => dest.PreviousId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Entity, BoughtProduct>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
        }
    }
}
