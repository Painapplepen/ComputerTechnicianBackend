using ComputerTechnicianBackend.Data.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.Data.EF.SQL
{
    public class ComputerTechnicianDbContext : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProductManufacture> OrderProductManufactures { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<Phone> Phones{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBasket> ProductBaskets { get; set; }
        public DbSet<ProductManufacture> ProductManufactures { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestOrder> RequestOrders { get; set; }
        public DbSet<RequestProductManufacture> RequestProductManufactures { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierProductManufacture> SupplierProductManufactures { get; set; }
        public DbSet<User> Users { get; set; }

        public ComputerTechnicianDbContext(DbContextOptions<ComputerTechnicianDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
