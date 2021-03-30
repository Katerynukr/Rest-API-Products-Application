using FluentAssertions;
using RestAPIApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestAPIUniTest
{
    public class DiscountServiceTest
    {
        [Fact]
        public void CulculateDiscount_GivenRegularPrice_CalculatesCorrectDiscount()
        {
            //Arrange
            var price = 5.0M;
            var discountService = new DiscountService();
            //Act
            var returnDiscount = discountService.CalculateDiscount(price);
            //Assert
            returnDiscount.Should().Be(0.5M);
        }
    }
}
