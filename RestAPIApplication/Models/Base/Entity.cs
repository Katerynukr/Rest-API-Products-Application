using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Models.Base
{
    public class Entity
    {
        public int? Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public bool Delete { get; set; } = false;
        public Shop Shop { get; set; }
        public int? ShopId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; } = 5.0M;
    }
}
