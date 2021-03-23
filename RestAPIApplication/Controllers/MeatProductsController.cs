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
    public class MeatProductsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MeatProductsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ViewProductDto> GetAll()
        {
            var entities = _context.MeatProducts.ToList();
            return _mapper.Map<List<ViewProductDto>>(entities);
        }

        [HttpGet("{id}")]
        public ViewProductDto GetById(int id)
        {
            var product =_context.MeatProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException();
            }
            return  _mapper.Map<ViewProductDto>(product);
        }

        [HttpPost]
        public void Create(ProductDto product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            var entity = _mapper.Map<MeatProducts>(product);
            _context.Add(entity);
            _context.SaveChanges();
        }

        [HttpPut]
        public void ModifyById(ModifyProductDto product)
        {
            var entity = _mapper.Map<MeatProducts>(product);
            _context.MeatProducts.Update(entity);
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

