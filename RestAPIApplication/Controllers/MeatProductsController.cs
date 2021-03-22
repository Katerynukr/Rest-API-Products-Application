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
        private readonly DataContext _context;

        public MeatProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<MeatProducts> GetAll()
        {
            return _context.MeatProducts.ToList();
        }

        [HttpGet("{id}")]
        public MeatProducts GetById(int id)
        {
            var product =_context.MeatProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpPost]
        public void Create(MeatProducts product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            _context.Add(product);
            _context.SaveChanges();
        }

        [HttpPut]
        public void ModifyById(MeatProducts product)
        {
            _context.MeatProducts.Update(product);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleateById(int id)
        {
            var product = _context.MeatProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            _context.MeatProducts.Remove(product);
            _context.SaveChanges();
        }
    }
}

