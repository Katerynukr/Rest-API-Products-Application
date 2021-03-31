using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestAPIApplication.Controllers;
using RestAPIApplication.Data;
using RestAPIApplication.Dtos;
using RestAPIApplication.Mappings;
using RestAPIApplication.Models;
using RestAPIApplication.Repositories;
using RestAPIApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestAPIUniTest
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task ProductCotrollerTest()
        {
            //Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            IMapper mapper = mockMapper.CreateMapper();
            var discountService = new DiscountService();
            var priceCalculationService = new PriceCalculationService(discountService);
            var mockContext = new DataContext(GetInMemoryDbContextOptions());
            var repository = new GenericRepository<DairyProduct>(mockContext, mapper);
            mockContext.Shops.Add(new Shop() { Id = 1 });
            var productController = new DairyProductsController(mapper, repository, priceCalculationService, mockContext);
            var productDto = new ProductDto()
            {
                Name = "Cheese",
                Price = 5,
                ShopId = 1
            };
            //Act
            await productController.UpserAsync(productDto);
            await productController.Buy(1, "Cheese");
            
            //Assert
            mockContext.BoughtProducts.Should().NotBeEmpty();
            mockContext.BoughtProducts.First().Price.Should().Be(4.5M);
        }

        public static DbContextOptions<DataContext> GetInMemoryDbContextOptions(string dbName = "Test_DB")
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return options;
        }
    }
}
