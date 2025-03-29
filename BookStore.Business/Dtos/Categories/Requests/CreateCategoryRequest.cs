using System;
using BookStore.Business.Dtos.Books.Responses;

namespace BookStore.Business.Dtos.Categories;

public class CreateCategoryRequest
{
    public string Name { get; set; } = null!;
}
