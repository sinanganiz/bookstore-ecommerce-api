using System;
using BookStore.Business.Dtos.Categories.Responses;

namespace BookStore.Business.Dtos.Books.Responses;

public class CreatedBookResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public CategoryResponse CategoryResponse { get; set; } = null!;
}
