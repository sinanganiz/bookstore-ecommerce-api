
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.Dtos.Books.Requests;
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class BookService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BookService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookResponse>> ListBooks()
    {
        try
        {
            List<Book> books = await _context.Books.ToListAsync();
            List<BookResponse> booksResponseList = _mapper.Map<List<BookResponse>>(books);

            return booksResponseList;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex + "ListBooks işleminde hata oluştu.");
            throw;
        }

    }

    public async Task<CreatedBookResponse> CreateBook(CreateBookRequest createBookRequest)
    {
        try
        {
            // Request'ten Book entity'sine dönüşüm
            Book book = _mapper.Map<Book>(createBookRequest);

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            var bookWithCategory = await _context.Books
                                        .Include(b => b.Category)
                                        .FirstOrDefaultAsync(b => b.Id == book.Id);

            // bookWithCategory entity sinden response nesnesine dönüşüm
            return _mapper.Map<CreatedBookResponse>(bookWithCategory);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex + "CreateBook işleminde hata oluştu.");
            throw;
        }

    }

    public async Task<UpdatedBookResponse> UpdateBook(int bookId, UpdateBookRequest updateBookRequest)
    {
        try
        {
            Book? book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                throw new Exception("Kitap bulunamadı");
            }

          
            
            // Bu kullanımda mevcut nesneye (book) map etmek için kullanılır.
            // request içindeki güncel  veriler, book nesnesine map edilir.
            _mapper.Map(updateBookRequest, book);

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            var bookWithCategory = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == book.Id);

            return _mapper.Map<UpdatedBookResponse>(bookWithCategory);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex + "UpdateBook işleminde hata oluştu.");
            throw;
        }
    }
}
