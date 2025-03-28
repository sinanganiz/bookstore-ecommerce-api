using System;
using BookStore.Business.Dtos.Categories.Responses;

namespace BookStore.Business.Dtos.Books.Responses;

public class UpdatedBookResponse
{
    public int Id { get; set; }
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
    public CategoryResponse CategoryResponse { get; set; } = null!;
}
