using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;

namespace Store.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<QuantityPerUnit> QuantityPerUnits { get; set; }



        // Override OnModelCreating 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Supplier>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<QuantityPerUnit>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<QuantityPerUnit>().HasData(
                new QuantityPerUnit { Id = 1, Name = "Kilo" },
                new QuantityPerUnit { Id = 2, Name = "box" },
                new QuantityPerUnit { Id = 3, Name = "can" },
                new QuantityPerUnit { Id = 4, Name = "liter" },
                new QuantityPerUnit { Id = 5, Name = "bottle" }
                );
        }
    }
}
