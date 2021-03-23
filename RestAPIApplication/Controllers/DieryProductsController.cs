using AutoMapper;
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
    public class DieryProductsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DieryProductsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ViewProductDto> GetAll()
        {
           var entities = _context.DieryProducts.ToList();
            return _mapper.Map<List<ViewProductDto>>(entities);
        }

        [HttpGet("{id}")]
        public ViewProductDto GetById(int id)
        {
            var product = _context.DieryProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            var dto = _mapper.Map<ViewProductDto>(product);
            return dto;
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
        public void Create(ProductDto product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            var entity = _mapper.Map<DieryProducts>(product);
            _context.Add(entity);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Modify(ModifyProductDto product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            var entity = _mapper.Map<DieryProducts>(product);
            _context.DieryProducts.Update(entity);
            _context.SaveChanges();
        }
    }
}
