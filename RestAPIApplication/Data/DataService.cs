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
        public List<Vegetables> Vegetables { get; set; }
        public List<Fruits> Fruits { get; set; }
        public List<MeatProducts> MeatProducts { get; set; }
        public List<DieryProducts> DieryProducts{ get; set; }

        public DataService()
        {
            Vegetables = new List<Vegetables>();
            Fruits = new List<Fruits>();
            MeatProducts = new List<MeatProducts>();
            DieryProducts = new List<DieryProducts>();
        }
    }
}
