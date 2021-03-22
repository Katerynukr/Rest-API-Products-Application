using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Data;
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
    public class ShopController : ControllerBase 
    {
        private readonly DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Shop> GetAll()
        {
            return _context.Shops.ToList();
        }

        [HttpGet("{id}")]
        public Shop GetById(int id)
        {
            var shop = _context.Shops.FirstOrDefault(p => p.Id == id);
            if (shop == null)
            {
                throw new KeyNotFoundException();
            }
            return shop;
        }

        [HttpPost]
        public void Create(Shop shop)
        {
            if (shop == null)
            {
                throw new Exception();
            }
            _context.Add(shop);
            _context.SaveChanges();
        }

        [HttpPut]
        public void ModifyById(Shop shop)
        {
            _context.Update(shop);
            _context.SaveChanges();
            //var shopToReplace = _context.Shop.FirstOrDefault(p => p.Id == shop.Id);
            //if (shopToReplace == null)
            //{
            //    throw new KeyNotFoundException();
            //}
            //foreach (var vegetable in _context.Shop)
            //{
            //    if (vegetable.Id == shop.Id)
            //    {
            //        vegetable.Id = shop.Id;
            //        vegetable.Name = shop.Name;
            //    }
            //}
        }

        [HttpDelete("{id}")]
        public void DeleateById(int id)
        {
            var shop = _context.Shops.FirstOrDefault(p => p.Id == id);
            if (shop == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Shops.Remove(shop);
            _context.SaveChanges();
        }
    }
}
