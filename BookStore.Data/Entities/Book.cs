using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public string Isbn { get; set; }
    public string PublishingHouse { get; set; }
    public string ImageUrl { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public DateOnly PublishedDate { get; set; }

}
