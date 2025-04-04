using BookStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.Data.Repositories.Abstracts;

public interface IBookRepository : IRepository<Book, int>
{
    Task<Book?> GetBookWithCategoryByIdAsync(int id);
}