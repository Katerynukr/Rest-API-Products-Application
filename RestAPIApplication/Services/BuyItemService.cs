using AutoMapper;
using RestAPIApplication.Interfaces;
using RestAPIApplication.Models;
using RestAPIApplication.Models.Base;
using RestAPIApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Services
{
    public class BuyItemService<T> : IBuyItemService<T> where T : Entity
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<T> _repository;
        private readonly IPriceCalculationService _priceCalculationService;

        public BuyItemService(IMapper mapper, IGenericRepository<T> repository, 
            IPriceCalculationService priceCalculationService)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculationService = priceCalculationService;
        }

        public async Task BuyItem(int amount, int id)
        {
            var entityToBuy = _repository.GetById(id);
            var dtoProductToBuyWithDiscount = _priceCalculationService.ApplyDiscount(entityToBuy, amount);
            var entityForHistory = _mapper.Map<BoughtProduct>(dtoProductToBuyWithDiscount);
            entityForHistory.Id = null;
            await _repository.AddToSalesHistory(entityForHistory);
           await _repository.RemoveProducts(entityToBuy, amount);
        }
    }
}
