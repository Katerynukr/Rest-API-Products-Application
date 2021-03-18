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
    public class VegetablesController : ControllerBase
    {
        private readonly VegetablesDataService _vegetablesDataService;

        public VegetablesController(VegetablesDataService vegetablesDataService)
        {
            _vegetablesDataService = vegetablesDataService;
        }

        [HttpGet]
        public List<Vegetables> GetAll()
        {
            return _vegetablesDataService.Vegetables;
        }

        [HttpGet("{id}")]
        public Vegetables GetById(int id)
        {
            var product = _vegetablesDataService.Vegetables.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpPost]
        public void Create(Vegetables product)
        {
            var productToCreate = _vegetablesDataService.Vegetables.FirstOrDefault(p => p.Id == product.Id);
            if (productToCreate != null)
            {
                throw new Exception();
            }
            _vegetablesDataService.Vegetables.Add(product);
        }

        [HttpPut]
        public void ModifyById(Vegetables product)
        {
            var productToReplace = _vegetablesDataService.Vegetables.FirstOrDefault(p => p.Id == product.Id);
            if (productToReplace == null)
            {
                throw new KeyNotFoundException();
            }
            foreach (var vegetable in _vegetablesDataService.Vegetables)
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
            var product = _vegetablesDataService.Vegetables.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            _vegetablesDataService.Vegetables.Remove(product);
        }


    }
}
