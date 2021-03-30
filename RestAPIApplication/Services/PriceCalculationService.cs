using RestAPIApplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Services
{
    public class PriceCalculationService
    {
        private readonly DiscountService _discountService;

        public PriceCalculationService(DiscountService discountService)
        {
            _discountService = discountService;
        }

        public ProductDto ApplyDiscount(ProductDto dto)
        {
            if (dto.Price.HasValue)
            {
                dto.Price = dto.Price - _discountService.CalculateDiscount(dto.Price.Value);
            }

            return dto;
        }
        public ProductDto ApplyDiscountMax(ProductDto dto)
        {
            if (dto.Price.HasValue)
            {
                dto.Price = dto.Price - _discountService.CalculateMaxDiscount(dto.Price.Value);
            }
            return dto;
        }
    }
}
