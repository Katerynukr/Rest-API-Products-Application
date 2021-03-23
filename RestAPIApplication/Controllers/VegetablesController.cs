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
    public class VegetablesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VegetablesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ViewProductDto> GetAll()
        {
            var entities = _context.Vegetables.ToList();
            return _mapper.Map<List<ViewProductDto>>(entities);
        }

        [HttpGet("{id}")]
        public ViewProductDto GetById(int id)
        {
            var entity = _context.Vegetables.FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }            
            return _mapper.Map<ViewProductDto>(entity);
        }

        [HttpPost]
        public void Create(ProductDto product)
        {
            if (product == null)
            {
                throw new Exception();
            }
            var entity = _mapper.Map<Vegetables>(product);
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
            var entity = _mapper.Map<Vegetables>(product);
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
