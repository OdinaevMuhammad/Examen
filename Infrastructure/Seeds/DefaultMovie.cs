using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;

public static class DefaultMovieSeed
{
    public static void MovieSeed(this ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 1 ,
                MovieYear = 2022,
                Title = "SpiderMan 2",
                CategoryId = 1
            },
            new Movie
            {
              MovieId = 2 ,
                MovieYear = 2022,
                Title = "SpiderMan 3",
                  CategoryId = 2
            },
            new Movie
            {
             MovieId = 3 ,
                MovieYear = 2022,
                Title = "SpiderMan 4",
                  CategoryId = 3
            }
        );
    }
}