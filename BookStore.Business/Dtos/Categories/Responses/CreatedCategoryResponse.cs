using System;
using BookStore.Business.Dtos.Books.Responses;

namespace BookStore.Business.Dtos.Categories;

public class CreatedCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

}
