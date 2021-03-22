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
        private readonly DataContext _context;

        public VegetablesController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Vegetables> GetAll()
        {
            return _context.Vegetables.ToList();
        }

        [HttpGet("{id}")]
        public Vegetables GetById(int id)
        {
            var product = _context.Vegetables.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpPost]
        public void Create(Vegetables product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            _context.Add(product);
            _context.SaveChanges();
        }

        [HttpPut]
        public void ModifyById(Vegetables product)
        {
            _context.Update(product);
            _context.SaveChanges();
            //var productToReplace = _context.Vegetables.FirstOrDefault(p => p.Id == product.Id);
            //if (productToReplace == null)
            //{
            //    throw new KeyNotFoundException();
            //}
            //foreach (var vegetable in _context.Vegetables)
            //{
            //    if (vegetable.Id == product.Id)
            //    {
            //        vegetable.Id = product.Id;
            //        vegetable.Name = product.Name;
            //    }
            //}
        }

        [HttpDelete("{id}")]
        public void DeleateById(int id)
        {
            var product = _context.Vegetables.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Vegetables.Remove(product);
            _context.SaveChanges();
        }
    }
}
