using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstEFProject
{
    class EntityFrameContext : DbContext
    {
        private const string connectionString = @"Server=DESKTOP-Q3S933H\SQLEXPRESS;Database=ECommerce;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> tblCustomer { get; set; }
    }
}
