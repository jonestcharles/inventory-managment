using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagement.DAL;
using System;
using System.Linq;

namespace InventoryManagement.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InventoryManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<InventoryManagementContext>>()))
            {
                // Look for any movies.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Product
                    {
                        SKU = "0000000001",
                        ProductDescription = "Green T-Shirt"
                    },
                    new Product
                    {
                        SKU = "0000000002",
                        ProductDescription = "Blue Jeans"
                    },
                    new Product
                    {
                        SKU = "0000000003",
                        ProductDescription = "Yellow Shoes"
                    }
                );

                context.Bins.AddRange(
                    new Bin
                    {
                        BinName = "A"
                    },
                    new Bin
                    {
                        BinName = "B"
                    },
                    new Bin
                    {
                        BinName = "C"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
