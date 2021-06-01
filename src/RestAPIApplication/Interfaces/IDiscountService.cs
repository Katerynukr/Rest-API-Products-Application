using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Interfaces
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(decimal price, int amount);
    }
}
