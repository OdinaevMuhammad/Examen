using Domain.Entities;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cast>().HasKey(c => new { c.ActorId, c.MovieId });

        modelBuilder.Entity<Cast>()
        .HasOne<Actor>( a => a.Actor)
        .WithMany(c => c.Cast)
        .HasForeignKey(a => a.ActorId);

        modelBuilder.Entity<Cast>()
        .HasOne<Movie>(m => m.Movie)
        .WithMany(c => c.Casts)
        .HasForeignKey(m => m.MovieId);

        modelBuilder.CategorySeed();
        modelBuilder.ActorSeed();
        modelBuilder.MovieSeed();
    } 

    public DbSet<Actor> Actors { get; set;}
    public DbSet<Cast> Casts { get; set;}
    public DbSet<Category> Categories { get; set;}
    public DbSet<Movie> Movies { get; set;}
}
