using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;

public static class DefaultActorSeed
{
    public static void ActorSeed(this ModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Actor>().HasData(
            new Actor
            {
                ActorId = 1,
                FullName = "JimKerry",
                Gender = 1,
                BirthYear = 1980,
                DeathYear = 2030
            },
            new Actor
            {
                ActorId = 2,
                FullName = "BredPit",
                Gender = 1,
                BirthYear = 1990,
                DeathYear = 2022
            },
                new Actor
            {
                ActorId = 3,
                FullName = "JohnUick",
                Gender = 1,
                BirthYear = 1970,
                DeathYear = 2032
            }

        );
    }
}