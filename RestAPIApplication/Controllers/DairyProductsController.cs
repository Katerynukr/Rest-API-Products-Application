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
        private readonly BuyItemService<DairyProduct> _buyItemService;

        public DairyProductsController(IMapper mapper, GenericRepository<DairyProduct> repository, 
            BuyItemService<DairyProduct> buyItemService) : base (mapper , repository)
        {
            _mapper = mapper;
            _repository = repository;
            _buyItemService = buyItemService;
        }

        [HttpGet]
        public async override Task<List<ProductDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        //id {}
        [HttpPost("{id}/Buy")]
        public async Task Buy(int id, int amount)
        {
             await _buyItemService.BuyItem(amount, id);
        }
    }
}
