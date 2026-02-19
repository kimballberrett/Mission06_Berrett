using Microsoft.EntityFrameworkCore;

namespace Mission06_Berrett.Models;

// Bridge between the C# models and the SQLite database
// Injected into the controller via dependency injection in Program.cs
public class MovieCollectionContext : DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
    }

    // Maps the Movie model to the Movies table in the database
    public DbSet<Movie> Movies { get; set; }

    // Maps the Category model to the Categories lookup table
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed the eight categories that match Joel's existing database
        // These IDs must match the CategoryId values stored in the Movies table
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
            new Category { CategoryId = 2, CategoryName = "Drama" },
            new Category { CategoryId = 3, CategoryName = "Television" },
            new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
            new Category { CategoryId = 5, CategoryName = "Comedy" },
            new Category { CategoryId = 6, CategoryName = "Family" },
            new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
            new Category { CategoryId = 8, CategoryName = "VHS" }
        );
    }
}
