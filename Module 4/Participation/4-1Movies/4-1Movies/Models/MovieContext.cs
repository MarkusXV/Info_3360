using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4_1Movies.Models
{
  public class MovieContext : DbContext
  {
    /// <summary>
    /// MovieContext Constructor with the Connection String and Connection options
    /// </summary>
    /// <param name="options"></param>
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {}
    public DbSet<Movie> Movies { get; set; } = null!; //Database Table called Movies initilized
    public DbSet<Genre> Genres { get; set; } = null!; //Database Table called Genres initilized

    /// <summary>
    /// Creates the Model using the Model Builder parameter
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Genre>().HasData( //Builds the Genre table with the following seed data
        new Genre { GenreId = "A", Name = "Action" },
        new Genre { GenreId = "C", Name = "Comedy" },
        new Genre { GenreId = "D", Name = "Drama" },
        new Genre { GenreId = "H", Name = "Horror" },
        new Genre { GenreId = "M", Name = "Musical" },
      new Genre { GenreId = "R", Name = "RomCom" },
      new Genre { GenreId = "S", Name = "SciFi" }
      );

      modelBuilder.Entity<Movie>().HasData( // Builds the Movie table with the following seed data
        new Movie
        {
          MovieId = 1,
          Name = "Casablanca",
          Year = 1942,
          GenreId = "D",
          Rating = 5
        },

        new Movie
        {
          MovieId = 2,
          Name = "Wonder Woman",
          Year = 2017,
          GenreId = "A",
          Rating = 3
        },

        new Movie
        {
          MovieId = 3,
          Name = "Moonstruck",
          Year = 1988,
          GenreId = "R",
          Rating = 4
        },

        new Movie
        {
          MovieId = 4,
          Name = "Peter's Peppers",
          Year = 2023,
          GenreId = "C",
          Rating = 5
        }
        );
        
    }




  }
}
