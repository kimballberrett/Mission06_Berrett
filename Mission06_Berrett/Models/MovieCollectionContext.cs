using Microsoft.EntityFrameworkCore;

namespace Mission06_Berrett.Models;

// Connects the Movie model to the SQLite database
public class MovieCollectionContext : DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
    }
    
    // Represents the Movies table in the database
    public DbSet<Movie> Movies { get; set; }
}