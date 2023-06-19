using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class Database : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<User> Users { get; set; }

        private string _connectionString = "Server=localhost;User Id=root;Database=senhas;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
    }
}