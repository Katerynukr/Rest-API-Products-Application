using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string ShopName { get; set; }
        public bool Delete { get; set; } = false;
    }
}
