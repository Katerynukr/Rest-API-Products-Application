using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Data;
using RestAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeatProductsController : ControllerBase
    {
        private readonly DataService _meatProductsDataService;

        public MeatProductsController(DataService MeatProducts)
        {
           _meatProductsDataService = MeatProducts;
        }

        [HttpGet]
        public List<MeatProducts> GetAll()
        {
            return _meatProductsDataService.MeatProducts;
        }

        [HttpGet("{id}")]
        public MeatProducts GetById(int id)
        {
            var product =_meatProductsDataService.MeatProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpPost]
        public void Create(MeatProducts product)
        {
            var productToCreate =_meatProductsDataService.MeatProducts.FirstOrDefault(p => p.Id == product.Id);
            if (productToCreate != null)
            {
                throw new Exception();
            }
           _meatProductsDataService.MeatProducts.Add(product);
        }

        [HttpPut]
        public void ModifyById(MeatProducts product)
        {
            var productToReplace = _meatProductsDataService.MeatProducts.FirstOrDefault(p => p.Id == product.Id);
            if (productToReplace == null)
            {
                throw new KeyNotFoundException();
            }
            foreach (var vegetable in _meatProductsDataService.MeatProducts)
            {
                if (vegetable.Id == product.Id)
                {
                    vegetable.Id = product.Id;
                    vegetable.Name = product.Name;
                }
            }
        }

        [HttpDelete("{id}")]
        public void DeleateById(int id)
        {
            var product = _meatProductsDataService.MeatProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
           _meatProductsDataService.MeatProducts.Remove(product);
        }
    }
}

