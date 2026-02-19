using System.ComponentModel.DataAnnotations;

namespace Mission06_Berrett.Models;

// Represents a movie category (genre) lookup table
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
