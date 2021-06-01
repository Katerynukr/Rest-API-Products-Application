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
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<MeatProduct> MeatProducts { get; set; }
        public DbSet<DairyProduct> DairyProducts { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<BoughtProduct> BoughtProducts{ get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
