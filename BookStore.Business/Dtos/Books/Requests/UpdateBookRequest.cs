
namespace BookStore.Business.Dtos.Books.Requests;

public class UpdateBookRequest
{

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Author { get; set; }
    public int PageCount { get; set; }
    public string? Isbn { get; set; }
    public string? PublishingHouse { get; set; }
    public string? ImageUrl { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public DateOnly? PublishedDate { get; set; }

    public int CategoryId { get; set; }
}
