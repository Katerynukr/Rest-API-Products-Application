using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIApplication.Data;
using RestAPIApplication.Dtos;
using RestAPIApplication.Models;
using RestAPIApplication.Models.Base;
using RestAPIApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Repositories
{
    public class GenericRepository<T> where T : Entity
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly PriceCalculationService _priceCalculationService;

        public GenericRepository(DataContext context, IMapper mapper, PriceCalculationService priceCalculationService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _priceCalculationService = priceCalculationService;
        }
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentException();
            }
            return entity;
        }
        public async Task UpserAsync(T entity)
        {
            if (entity.Id != null)
            {
                _context.Update(entity);
            }
            else
            {
                _context.Add(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleateById(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _context.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Buy(List<T> entities, int amount, string name)
        {
            var filteredEntities = entities.FindAll(e => e.Name.Contains(name));
            int count = 0;
            if (amount <= 5 && amount > 0)
            {
                foreach (var entity in filteredEntities)
                {
                    if (count < amount)
                    {
                        var dto = _mapper.Map<ProductDto>(entity);
                        var bought = _priceCalculationService.ApplyDiscount(dto);
                        await this.AddToBoughtProducts(bought);
                        await this.RemoveWhenBough(entity);
                        count++;
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
                        await this.AddToBoughtProducts(bought);
                        await this.RemoveWhenBough(entity);
                        count++;
                    }
                }
            }
        } 

        private async Task AddToBoughtProducts(ProductDto dto)
        {
            if (dto != null)
            {
                var boutghtEntity = _mapper.Map<BoughtProduct>(dto);
                boutghtEntity.Id = null;
                _context.BoughtProducts.Add(boutghtEntity);
            }
            await _context.SaveChangesAsync();
        }

        private async Task RemoveWhenBough(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
            await _context.SaveChangesAsync();
        }
    }
}
