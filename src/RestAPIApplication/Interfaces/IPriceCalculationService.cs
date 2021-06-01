using RestAPIApplication.Dtos;
using RestAPIApplication.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Interfaces
{
    public interface IPriceCalculationService
    {
        ProductDto ApplyDiscount(Entity entity, int amount);
    }
}
