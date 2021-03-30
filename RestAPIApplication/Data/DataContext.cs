using Microsoft.EntityFrameworkCore;
using RestAPIApplication.Models;
using RestAPIApplication.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Vegetables> Vegetables { get; set; }
        public DbSet<MeatProducts> MeatProducts { get; set; }
        public DbSet<DieryProducts> DieryProducts { get; set; }
        public DbSet<Fruits> Fruits { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<BoughtProduct> BoughtProducts{ get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
