using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces;
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
        private readonly ITenantProvider _tenantProvider;

        public AppDbContext(DbContextOptions<AppDbContext> options, ITenantProvider tenantProvider) : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasQueryFilter(u => u.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<Product>().HasQueryFilter(u => u.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<User>().HasQueryFilter(u => u.TenantId == _tenantProvider.TenantId);
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
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product-1",
                Price = 100,
                TenantId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Product-2",
                Price = 200,
                TenantId = 1
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ITenantEntity>())
            {
                if (entry.State == EntityState.Added && entry.Entity.TenantId == 0)
                {
                    entry.Entity.TenantId = _tenantProvider.TenantId;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}