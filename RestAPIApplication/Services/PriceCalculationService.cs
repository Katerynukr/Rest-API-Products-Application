using AutoMapper;
using RestAPIApplication.Dtos;
using RestAPIApplication.Interfaces;
using RestAPIApplication.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Services
{
    public class PriceCalculationService : IPriceCalculationService
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public PriceCalculationService(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        public ProductDto ApplyDiscount(Entity entity, int amount)
        {
            var productDto = _mapper.Map<ProductDto>(entity);
            if (productDto.Price.HasValue && productDto.Quantity >= amount)
            {
                productDto.Quantity = amount;
                productDto.Price = productDto.Price - _discountService.CalculateDiscount(productDto.Price.Value, amount);
            }
            return productDto;
        }
    }
}
