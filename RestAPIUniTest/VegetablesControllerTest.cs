using AutoMapper;
using FluentAssertions;
using Moq;
using RestAPIApplication.Controllers;
using RestAPIApplication.Data;
using RestAPIApplication.Interfaces;
using RestAPIApplication.Mappings;
using RestAPIApplication.Models;
using RestAPIApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestAPIUnitTest
{
    public class VegetablesControllerTest
    {

        [Fact]
        public async Task GetAll_VegetableControllerTesting()
        {

            //Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            IMapper mapper = mockMapper.CreateMapper();
            var discountService = new DiscountService();
            var priceCalculationService = new PriceCalculationService(discountService, mapper);
            var repository = new Mock<IGenericRepository<Vegetable>>();
            repository.Setup(r => r.GetAll()).ReturnsAsync(new List<Vegetable>()
            {
                new Vegetable()
                {
                    Price = 4M
                }
            });
            var serviceBuyItem = new BuyItemService<Vegetable>(mapper, repository.Object, priceCalculationService);
            var vegetablesController = new VegetablesController(mapper, repository.Object, serviceBuyItem);

            //Act
            var result = vegetablesController.GetAll();
            //Assert
            result.Should().NotBeNull();
        
        }
      
    }
}
