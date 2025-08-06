using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product-1",
                Price = 100
            },
            new Product
            {
                Id = 2,
                Name = "Product-2",
                Price = 200
            }
            );
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant
                {
                    Id = 1,
                    Name = "Tenant-1"
                },
                new Tenant
                {
                    Id = 2,
                    Name = "Tenant-2"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Username-1",
                    PasswordHash = "PasswordHash",
                    Email = "email@email.com",
                    TenantId = 1
                }
            );
        }
    }
}