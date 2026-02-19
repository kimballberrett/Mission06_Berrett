using System.ComponentModel.DataAnnotations;

namespace Mission06_Berrett.Models;

// Lookup table for movie categories (e.g. Drama, Comedy, Action/Adventure)
// Stored in its own table so categories can be managed independently of movies
public class Category
{
    // Primary key — auto-incremented by SQLite
    [Key]
    public int CategoryId { get; set; }

    // Human-readable name displayed in dropdowns and the movie list
    public string CategoryName { get; set; }
}
