
using BookStore.Business.Dtos;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class BookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public List<BookResponse> ListBooks()
    {
        List<Book> books = _context.Books.ToList();
        List<BookResponse> booksResponseList = new();

        books.ForEach(book =>
        {
            BookResponse bookResponse = new();
            bookResponse.Id = book.Id;
            bookResponse.Title = book.Title;
            bookResponse.Description = book.Title;

            booksResponseList.Add(bookResponse);
        });

        return booksResponseList;
    }
}
