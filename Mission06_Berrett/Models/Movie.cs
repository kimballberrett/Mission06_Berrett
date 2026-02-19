using System.ComponentModel.DataAnnotations;

namespace Mission06_Berrett.Models;

// Represents a single movie in Joel's collection
public class Movie
{
    // Primary key for the Movies table
    [Key]
    public int MovieId { get; set; }

    [Required]
    public string Title { get; set; }

    // FK to Categories table
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public string? Director { get; set; }

    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
    public int Year { get; set; }

    public string? Rating { get; set; }

    public bool Edited { get; set; }

    [Required]
    public bool CopiedToPlex { get; set; }

    public string? LentTo { get; set; }

    // Notes are limited to 25 characters
    [MaxLength(25)]
    public string? Notes { get; set; }
}
