using Microsoft.AspNetCore.Mvc;
using BookStore.Business.Services;
using Microsoft.AspNetCore.Authorization;
using BookStore.Business.Constants;
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Business.Dtos.Books.Requests;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<BookResponse>>> List()
    {
        var bookResponses = await _bookService.GetAllBooksAsync();
        return Ok(bookResponses);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<BookResponse>> GetByBookId(int id)
    {
        var bookResponse = await _bookService.GetBookByIdAsync(id);
        return Ok(bookResponse);
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreatedBookResponse>> CreateBook(CreateBookRequest createBookRequest)
    {
        var createdBookResponse = await _bookService.AddBookAsync(createBookRequest);
        return Ok(createdBookResponse);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<UpdatedBookResponse>> UpdateBook(int id, [FromBody] UpdateBookRequest updateBookRequest)
    {
        var updatedBookResponse = await _bookService.UpdateBookAsync(id, updateBookRequest);
        return Ok(updatedBookResponse);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
