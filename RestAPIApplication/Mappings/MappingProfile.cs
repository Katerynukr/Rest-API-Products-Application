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
            CreateMap<ViewProductDto, Vegetables>().ReverseMap();
            CreateMap<ProductDto, Vegetables>().ReverseMap();
            CreateMap<ModifyProductDto, Vegetables>().ReverseMap();
            CreateMap<ViewProductDto, Fruits>().ReverseMap();
            CreateMap<ProductDto, Fruits>().ReverseMap();
            CreateMap<ModifyProductDto, Fruits>().ReverseMap();
            CreateMap<ViewProductDto, DieryProducts>().ReverseMap();
            CreateMap<ProductDto, DieryProducts>().ReverseMap();
            CreateMap<ModifyProductDto, DieryProducts>().ReverseMap();
            CreateMap<ViewProductDto, MeatProducts>().ReverseMap();
            CreateMap<ProductDto, MeatProducts>().ReverseMap();
            CreateMap<ModifyProductDto, MeatProducts>().ReverseMap();
        }
    }
}
