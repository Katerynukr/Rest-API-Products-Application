using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Services
{
    public class DiscountService
    {
        private int discountPercentage = 10;
        private int discountPercentageMax = 20;
        public decimal CalculateDiscount(decimal price)
        {
            return price / 100 * discountPercentage;
        }
        public decimal CalculateMaxDiscount(decimal price)
        {
            return price / 100 * discountPercentageMax;
        }
    }
}
