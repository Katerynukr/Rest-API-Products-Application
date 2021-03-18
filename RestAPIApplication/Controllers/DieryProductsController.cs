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
    public class DieryProductsController : ControllerBase
    {
        private readonly DataService _dieryProductsDataService;

        public DieryProductsController(DataService dierytProductsDataService)
        {
            _dieryProductsDataService = dierytProductsDataService;
        }

        [HttpGet]
        public List<DieryProducts> GetAll()
        {
            return _dieryProductsDataService.DieryProducts;
        }

        [HttpGet("{id}")]
        public DieryProducts GetById(int id)
        {
            var product = _dieryProductsDataService.DieryProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpDelete("{id}")]
        public void RemoveById(int id)
        {
            var productToRemove = _dieryProductsDataService.DieryProducts.FirstOrDefault(p => p.Id == id);
            if (productToRemove == null)
            {
                throw new KeyNotFoundException();
            }
            _dieryProductsDataService.DieryProducts.Remove(productToRemove);
        }

        [HttpPost]
        public void Create(DieryProducts product)
        {
            var productToCreate = _dieryProductsDataService.DieryProducts.FirstOrDefault(p => p.Id == product.Id);
            if (productToCreate != null)
            {
                throw new Exception();
            }
            _dieryProductsDataService.DieryProducts.Add(product);
        }

        [HttpPut]
        public void Modify(DieryProducts product)
        {
            var productToReplace = _dieryProductsDataService.DieryProducts.FirstOrDefault(p => p.Id == product.Id);
            if (productToReplace == null)
            {
                throw new KeyNotFoundException();
            }
            foreach (var dieryProduct in _dieryProductsDataService.DieryProducts)
            {
                if (dieryProduct.Id == product.Id)
                {
                    dieryProduct.Id = product.Id;
                    dieryProduct.Name = product.Name;
                }
            }
        }
    }
}
