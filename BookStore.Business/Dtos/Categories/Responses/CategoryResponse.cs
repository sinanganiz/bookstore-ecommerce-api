using System;

namespace BookStore.Business.Dtos.Categories.Responses;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
