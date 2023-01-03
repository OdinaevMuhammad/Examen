using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;

public static class DefaultCategorySeed
{
    public static void CategorySeed(this ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
               CategoryId = 1,
               Title = "Action"
            },
            new Category
            {
              CategoryId = 2,
               Title = "Comedy"
            },
            new Category
            {
              CategoryId = 3,
               Title = "Fantasy"
            }
        );
    }
}