using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Admin> Administrator { get; set; }
        public DbSet<User> User { get; set; }
        //public DbSet<BasketItem> BasketItem { get; set; }
        //public DbSet<Order> Order { get; set; }
        //public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set;}

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
