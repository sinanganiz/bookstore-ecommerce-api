using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Entities;

[Table("Books")]
public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [MaxLength(1000)]
    [Required]
    public string Description { get; set; } = null!;
    public string? Author { get; set; }
    public int PageCount { get; set; }
    public string? Isbn { get; set; }
    public string? PublishingHouse { get; set; }
    public string? ImageUrl { get; set; }
    public int Stock { get; set; } 
    public double Price { get; set; }
    public DateOnly? PublishedDate { get; set; }

    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
