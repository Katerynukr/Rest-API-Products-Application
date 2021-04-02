using RestAPIApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Services
{
    public class DiscountService : IDiscountService
    {
        private int discountPercentage = 10;
        private int discountPercentageMax = 20;
        public decimal CalculateDiscount(decimal price, int amount)
        {
            if(amount <= 5 && amount > 0) 
            {
                return price / 100 * discountPercentage;
            }
            else if(amount > 5 )
            {
                return price / 100 * discountPercentageMax;
            }
            return price;
        }
      
    }
}
