using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Controllers.Base;
using RestAPIApplication.Data;
using RestAPIApplication.Dtos;
using RestAPIApplication.Models;
using RestAPIApplication.Repositories;
using RestAPIApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DairyProductsController : GenericControllerBase<ProductDto, DairyProduct>
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<DairyProduct> _repository;

        public DairyProductsController(IMapper mapper, GenericRepository<DairyProduct> repository) : base(mapper, repository)
        {
           _mapper = mapper;
           _repository = repository;
        }

      [HttpGet]
        public async override Task<List<ProductDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        [HttpPost("{amount}/Buy")]
        public async Task Buy(int amount, string name)
        {
            var entities = await _repository.GetAll();
            await _repository.Buy(entities, amount , name);
            /*var filteredEntities = entities.FindAll(e => e.Name.Contains(Name));
            int count = 0;
            if (amount <= 5 && amount > 0)
            {
                foreach (var entity in filteredEntities)
                {
                    if (count < amount)
                    {
                        var dto = _mapper.Map<ProductDto>(entity);
                        var bought = _priceCalculationService.ApplyDiscount(dto);
                        var boutghtEntity = _mapper.Map<BoughtProduct>(bought);
                        boutghtEntity.Id = null;
                        _context.BoughtProducts.Add(boutghtEntity);
                        _context.DairyProducts.Remove(entity);
                        count++;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else if (amount > 5)
            {
                foreach (var entity in filteredEntities)
                {
                    if (count < amount)
                    {
                        var dto = _mapper.Map<ProductDto>(entity);
                        var bought = _priceCalculationService.ApplyDiscountMax(dto);
                        var boutghtEntity = _mapper.Map<BoughtProduct>(bought);
                        boutghtEntity.Id = null;
                        _context.BoughtProducts.Add(boutghtEntity);
                        _context.DairyProducts.Remove(entity);
                        count++;
                        await _context.SaveChangesAsync();
                    }
                }
            }*/
        }
    }
}
