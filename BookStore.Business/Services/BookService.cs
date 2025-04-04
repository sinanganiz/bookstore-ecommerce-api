using AutoMapper;
using BookStore.Business.Dtos.Books.Requests;
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;


namespace BookStore.Business.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        var bookResponseList = _mapper.Map<IEnumerable<BookResponse>>(books);
        return bookResponseList;
    }

    public async Task<BookResponse> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        var bookResponse = _mapper.Map<BookResponse>(book);
        return bookResponse;
    }

    public async Task<CreatedBookResponse> AddBookAsync(CreateBookRequest createBookRequest)
    {
        var book = _mapper.Map<Book>(createBookRequest);
        var addedBook = _bookRepository.AddAsync(book);

        var bookWithCategory = _bookRepository.GetBookWithCategoryByIdAsync(addedBook.Id);
        var createdBookResponse = _mapper.Map<CreatedBookResponse>(bookWithCategory);
        return createdBookResponse;
    }

    public async Task<UpdatedBookResponse> UpdateBookAsync(int id, UpdateBookRequest updateBookRequest)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        _mapper.Map(updateBookRequest, book);
        var updatedBook = await _bookRepository.UpdateAsync(book);

        var updatedBookWithCategory = await _bookRepository.GetBookWithCategoryByIdAsync(updatedBook.Id);

        var updatedBookResponse = _mapper.Map<UpdatedBookResponse>(updatedBookWithCategory);
        return updatedBookResponse;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        await _bookRepository.DeleteAsync(book);
    }


}
