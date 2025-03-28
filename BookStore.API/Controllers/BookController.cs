using Microsoft.AspNetCore.Mvc;

using BookStore.Business.Services;
using Microsoft.AspNetCore.Authorization;
using BookStore.Business.Constants;
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Business.Dtos.Books.Requests;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    public readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<BookResponse>>> List()
    {
        List<BookResponse> bookResponses = await _bookService.ListBooks();

        return bookResponses;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreatedBookResponse>> CreateBook(CreateBookRequest createBookRequest)
    {
        CreatedBookResponse createdBookResponse = await _bookService.CreateBook(createBookRequest);
        return Ok(createdBookResponse);
    }

    [HttpPut("update/{bookId}")]
    public async Task<ActionResult<UpdatedBookResponse>> UpdateBook(int bookId, [FromBody] UpdateBookRequest updateBookRequest)
    {
        UpdatedBookResponse updatedBookResponse = await _bookService.UpdateBook(bookId, updateBookRequest);
        return Ok(updatedBookResponse);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpGet("admin")]
    public IActionResult GetSecureAdminData()
    {
        return Ok("Tebrikler. Admin verisine ulaşabiliyorsunuz.");
    }

    [Authorize(Roles = Roles.Customer)]
    [HttpGet("customer")]
    public IActionResult GetSecureCustomerData()
    {
        return Ok("Tebrikler. Customer verisine ulaşabiliyorsunuz.");
    }
}
