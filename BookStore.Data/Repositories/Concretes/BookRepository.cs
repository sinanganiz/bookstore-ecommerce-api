using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories.Concretes;

public class BookRepository : Repository<Book, int>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context) { }

    public async Task<Book?> GetBookWithCategoryByIdAsync(int id)
    {
        return await _context.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}