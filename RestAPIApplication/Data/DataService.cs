using RestAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Data
{
    public class DataService
    {
        public List<Vegetable> Vegetables { get; set; }
        public List<Fruit> Fruits { get; set; }
        public List<MeatProduct> MeatProducts { get; set; }
        public List<DairyProduct> DairyProducts{ get; set; }

        public DataService()
        {
            Vegetables = new List<Vegetable>();
            Fruits = new List<Fruit>();
            MeatProducts = new List<MeatProduct>();
            DairyProducts = new List<DairyProduct>();
        }
    }
}
