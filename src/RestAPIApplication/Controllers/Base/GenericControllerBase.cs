using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Dtos;
using RestAPIApplication.Interfaces;
using RestAPIApplication.Models;
using RestAPIApplication.Models.Base;
using RestAPIApplication.Repositories;
using RestAPIApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Controllers.Base
{
    public class GenericControllerBase<TDto, TEntity> : ControllerBase where TDto  : DtoObject where TEntity : Entity
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TEntity> _repository;
        private readonly Interfaces.IBuyItemService<TEntity> _buyItemService;

        public GenericControllerBase(IMapper mapper, IGenericRepository<TEntity> repository, Interfaces.IBuyItemService<TEntity> buyItemService)
        {
            _mapper = mapper;
            _repository = repository;
            _buyItemService = buyItemService;
        }

        [HttpGet]
        public async virtual Task<List<TDto>> GetAll()
        { 
            var entities = await _repository.GetAll();
            return _mapper.Map<List<TDto>>(entities);
        } 

        [HttpGet("{id}")]
        public TDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<TDto>(entity);
        }

        [HttpPost]
        public async Task UpserAsync(TDto dto)
        {
            if (dto == null)
            {
                throw new Exception();
            }
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.UpserAsync(entity);
        }

        [HttpDelete("{id}")]
        public async Task DeleateByIdAsync(int id)
        {
            await _repository.DeleateById(id);
        }

        [HttpPost("Buy")]
        public async Task Buy(BuyItem buyItem)
        {
            await _buyItemService.BuyItem(buyItem.Quantity, buyItem.Id);
        }
    }
}
