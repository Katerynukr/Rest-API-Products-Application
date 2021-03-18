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
    public class FruitsController : ControllerBase
    {
        private readonly DataService _fruitsDataService;

        public FruitsController(DataService vegetablesDataService)
        {
            _fruitsDataService = vegetablesDataService;
        }

        [HttpGet]
        public List<Fruits> GetAll()
        {
            return _fruitsDataService.Fruits;
        }

        [HttpGet("{id}")]
        public Fruits GetById(int id)
        {
            var product = _fruitsDataService.Fruits.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpPost]
        public void Create(Fruits product)
        {
            var productToCreate = _fruitsDataService.Vegetables.FirstOrDefault(p => p.Id == product.Id);
            if (productToCreate != null)
            {
                throw new Exception();
            }
            _fruitsDataService.Fruits.Add(product);
        }

        [HttpPut]
        public void ModifyById(Models.Fruits product)
        {
            var productToReplace = _fruitsDataService.Fruits.FirstOrDefault(p => p.Id == product.Id);
            if (productToReplace == null)
            {
                throw new KeyNotFoundException();
            }
            foreach (var fruit in _fruitsDataService.Fruits)
            {
                if (fruit.Id == product.Id)
                {
                    fruit.Id = product.Id;
                    fruit.Name = product.Name;
                }
            }
        }

        [HttpDelete("{id}")]
        public void DeleateById(int id)
        {
            var product = _fruitsDataService.Fruits.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            _fruitsDataService.Fruits.Remove(product);
        }

    }
}

