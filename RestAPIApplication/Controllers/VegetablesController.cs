using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Data;
using RestAPIApplication.Dtos;
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
        public List<ViewProductDto> GetAll()
        {
            var entities = _context.Vegetables.ToList();
            var dtos = new List<ViewProductDto>();
            foreach (var entity in entities)
            {
                dtos.Add(new ViewProductDto()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ShopId = entity.ShopId
                });
            }
            return dtos;
        }

        [HttpGet("{id}")]
        public ViewProductDto GetById(int id)
        {
            var entity = _context.Vegetables.FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }
            var dto = new ViewProductDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                ShopId = entity.ShopId
            };
            
            return dto;
        }

        [HttpPost]
        public void Create(ProductDto product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            var entity = new Vegetables()
            {
                Name = product.Name,
                ShopId = product.ShopId
            };
            _context.Vegetables.Add(entity);
            _context.SaveChanges();
        }

        [HttpPut]
        public void ModifyById(ModifyProductDto product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            var entity = new Vegetables()
            {
                Id = product.Id,
                Name = product.Name,
                ShopId = product.ShopId
            };
            _context.Update(entity);
            _context.SaveChanges();
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
