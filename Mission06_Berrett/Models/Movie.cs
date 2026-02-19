using System.ComponentModel.DataAnnotations;

namespace Mission06_Berrett.Models;

// Represents a single movie in Joel's physical collection
public class Movie
{
    // Primary key — auto-incremented by SQLite
    [Key]
    public int MovieId { get; set; }

    // Title is required so the form rejects empty submissions
    [Required]
    public string Title { get; set; }

    // Foreign key linking to the Categories lookup table
    public int? CategoryId { get; set; }

    // Navigation property — lets us access Category.CategoryName without a manual join
    public Category? Category { get; set; }

    public string? Director { get; set; }

    // Year must be 1888 or later (first motion picture ever recorded)
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
    public int Year { get; set; }

    public string? Rating { get; set; }

    // Tracks whether the movie has been edited for content
    public bool Edited { get; set; }

    // Tracks whether the movie has been copied to Joel's Plex server
    [Required]
    public bool CopiedToPlex { get; set; }

    // Stores who currently has the movie borrowed, if anyone
    public string? LentTo { get; set; }

    // Notes are capped at 25 characters
    [MaxLength(25)]
    public string? Notes { get; set; }
}
