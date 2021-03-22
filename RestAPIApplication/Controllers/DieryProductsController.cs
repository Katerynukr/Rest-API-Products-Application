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
        private readonly DataContext _context;

        public DieryProductsController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<DieryProducts> GetAll()
        {
            return _context.DieryProducts.ToList();
        }

        [HttpGet("{id}")]
        public DieryProducts GetById(int id)
        {
            var product = _context.DieryProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpDelete("{id}")]
        public void RemoveById(int id)
        {
            var productToRemove = _context.DieryProducts.FirstOrDefault(p => p.Id == id);
            if (productToRemove == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Remove(productToRemove);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Create(DieryProducts product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            _context.Add(product);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Modify(DieryProducts product)
        {
            _context.DieryProducts.Update(product);
            _context.SaveChanges();
        }
    }
}
