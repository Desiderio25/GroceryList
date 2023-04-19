using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GroceryList.Data;
using System;
using System.Linq;

namespace GroceryList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GroceryListContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GroceryListContext>>()))
            {
                // Look for any Products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "Eggs",
                        Quantity= 1,
                        Price= 3,

                    },

                    new Product
                    {
                        Name = "Bread",
                        Quantity = 1,
                        Price = 2,
                    },

                    new Product
                    {
                        Name = "meat",
                        Quantity = 2,
                        Price = 3,
                    },

                    new Product
                    {
                        Name = "Peanut Butter",
                        Quantity = 1,
                        Price = 5,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}