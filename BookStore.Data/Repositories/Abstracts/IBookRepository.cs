using BookStore.Data.Entities;

namespace BookStore.Data.Repositories.Abstracts;

public interface IBookRepository : IRepository<Book, int>
{
    Task<Book?> GetBookWithCategoryByIdAsync(int id);
}