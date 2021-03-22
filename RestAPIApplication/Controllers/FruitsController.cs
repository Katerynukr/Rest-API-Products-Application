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
        private readonly DataContext _context;

        public FruitsController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Fruits> GetAll()
        {
            return _context.Fruits.ToList();
        }

        [HttpGet("{id}")]
        public Fruits GetById(int id)
        {
            var product = _context.Fruits.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return product;
        }

        [HttpPost]
        public void Create(Fruits product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            _context.Add(product);
            _context.SaveChanges();
        }

        [HttpPut]
        public void ModifyById(Models.Fruits product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleateById(int id)
        {
            var product = _context.Fruits.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Remove(product);
            _context.SaveChanges();
        }

    }
}

