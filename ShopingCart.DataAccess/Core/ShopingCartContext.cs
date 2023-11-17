using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.Core
{
    public class ShopingCartContext: DbContext
    {
        public DbSet<ShopingCart.Domain.Models.ShopingCart> ShopingCart { get; set; }
        public DbSet<ShopingCart.Domain.Models.ShopingDetails> ShopingDetails { get; set; }

        public ShopingCartContext(DbContextOptions<ShopingCartContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            
        }
    }
}
