using FluentAssertions;
using RestAPIApplication.Dtos;
using RestAPIApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestAPIUniTest
{
    public class PriceCalculationServiceTests
    {
        [Fact]
        public void ApplyDiscount_GivenRegularPrice_CalculatesCorrectDiscount()
        {
            //Arrange
            var product = new ProductDto()
            {
                Price = 5.00M
            };
            var discountService = new DiscountService();
            var priceCalculationService = new PriceCalculationService(discountService);
            //Act
            var returnDiscount = priceCalculationService.ApplyDiscount(product);
            //Assert
            returnDiscount.Price.Should().Be(4.5M);
        }

        [Fact]
        public void ApplyDiscountMax_GivenRegularPrice_CalculatesCorrectDiscount()
        {
            //Arrange
            var product = new ProductDto()
            {
                Price = 5.00M
            };
            var discountService = new DiscountService();
            var priceCalculationService = new PriceCalculationService(discountService);
            //Act
            var returnDiscount = priceCalculationService.ApplyDiscountMax(product);
            //Assert
            returnDiscount.Price.Should().Be(4.0M);
        }
    }
}
