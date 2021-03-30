using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Models.Base
{
    public class Product : Entity
    {
        public Shop Shop { get; set; }
        public int? ShopId { get; set; }
        public decimal? Price { get; set; } = 5.0M;
    }
}
