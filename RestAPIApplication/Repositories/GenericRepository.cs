using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIApplication.Data;
using RestAPIApplication.Dtos;
using RestAPIApplication.Interfaces;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            var entity = this.FindById(id);
            if (entity != null)
            {
                _context.Remove(entity);
            }
            await this.ContextSaveChangesAsync();
        }

        public T FindById(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentException();
            }
            return entity;
        }

        public async Task ContextSaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProducts(T entity, int amount)
        {
            if(entity.Quantity >= amount)
            {
                entity.Quantity -= amount;
                if(entity.Quantity == 0)
                {
                    _context.Set<T>().Remove(entity);
                }
            }
            else
            {
                throw new InvalidOperationException("You can not buy this amount of products.");
            }
            await this.ContextSaveChangesAsync();
        }

        public async Task AddToSalesHistory(BoughtProduct entity)
        {
            await _context.BoughtProducts.AddAsync(entity);
            await this.ContextSaveChangesAsync();
        }
    }
}
