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
    public class DieryProductsController : GenericControllerBase<ProductDto, DieryProducts>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly GenericRepository<DieryProducts> _repository;
        private readonly PriceCalculationService _priceCalculationService;

        public DieryProductsController(IMapper mapper, GenericRepository<DieryProducts> repository, 
            PriceCalculationService priceCalculationService, DataContext context) : base(mapper, repository)
        {
           _mapper = mapper;
           _repository = repository;
           _context = context;
           _priceCalculationService = priceCalculationService;
        }

      [HttpGet]
        public async override Task<List<ProductDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        [HttpPost("{amount}/Buy")]
        public async Task Buy(int amount, string Name)
        {
            var entities = await _repository.GetAll();
            var filteredEntities = entities.FindAll(e => e.Name.Contains(Name));
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
                        _context.DieryProducts.Remove(entity);
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
                        _context.DieryProducts.Remove(entity);
                        count++;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
