using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("wpfCon")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>().Property(c => c.Price).HasPrecision(5, 2);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Orders> Orders { get; set; }
    }
}
