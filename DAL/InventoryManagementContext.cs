using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.DAL
{
    /// <summary>
    /// DB Context for the Inventory Management app. Defines DB Tables for each Model
    /// </summary>
    public class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) : base(options)
        {
        }

        public DbSet<Bin> Bins { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Validation fro unique model fields
        /// </summary>
        /// <param name="builder">ModelBuilder for object to be added/modified</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Inventory>()
                .HasIndex(i => new { i.BinID, i.ProductID })
                .IsUnique();

            builder.Entity<Bin>()
                .HasAlternateKey(b => b.BinName);

            builder.Entity<Order>()
                .HasAlternateKey(o => o.OrderNumber);

            builder.Entity<Order>()
                .OwnsMany(o => o.OrderLines);

            builder.Entity<Product>()
                .HasAlternateKey(p => p.SKU);
        }
    }
}
