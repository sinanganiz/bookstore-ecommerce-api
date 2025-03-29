using System;
using BookStore.Business.Dtos.Books.Responses;

namespace BookStore.Business.Dtos.Categories;

public class UpdateCategoryRequest
{
    public string Name { get; set; } = null!;
}
