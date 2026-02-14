using System.ComponentModel.DataAnnotations;

namespace Mission06_Berrett.Models;

// Represents a single movie in Joel's collection
public class Movie
{
   // Primary key for the Movies table
   [Key]
   [Required]
   public int MovieID  { get; set; }
   public string Title  { get; set; }
   public string Genre { get; set; }
   public string Director  { get; set; }
   public int Year  { get; set; }
   public string Rating { get; set; }
   public bool Edited { get; set; }
   public string? LentTo { get; set; }
   // Notes are limited to 25 characters
   [MaxLength(25)]
   public string? Notes { get; set; }
}