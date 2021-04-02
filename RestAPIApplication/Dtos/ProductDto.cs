using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Dtos
{
    public class ProductDto : DtoObject
    {
        public int ShopId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; } = 5.00M;
    }
}
