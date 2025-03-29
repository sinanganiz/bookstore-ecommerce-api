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
    public async Task<ActionResult<List<BookResponse>>> List()
    {
        List<BookResponse> bookResponses = await _bookService.ListBooks();
        return bookResponses;
    }

    [HttpGet("get/{bookId}")]
    public async Task<ActionResult<BookResponse>> GetByBookId(int bookId)
    {

        try
        {
            BookResponse bookResponse = await _bookService.GetByBookId(bookId);
            return Ok(bookResponse);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception:", ex); // Add logger
            return StatusCode(StatusCodes.Status500InternalServerError, "Kitap bilgisi alınırken bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
        }

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

    [HttpDelete("delete/{bookId}")]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
        try
        {
            var result = await _bookService.DeleteBook(bookId);

            if (!result)
            {
                return NotFound($"ID: {bookId} olan kitap bulunamadı.");
            }

            return NoContent(); // 204 status code is the standard response for successful DELETE
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception:", ex); // Add logger
            return StatusCode(StatusCodes.Status500InternalServerError, "Kitap silme işlemi sırasında bir hata oluştu.");
        }
    }

    // [Authorize(Roles = Roles.Admin)]
    // [HttpGet("admin")]
    // public IActionResult GetSecureAdminData()
    // {
    //     return Ok("Tebrikler. Admin verisine ulaşabiliyorsunuz.");
    // }

    // [Authorize(Roles = Roles.Customer)]
    // [HttpGet("customer")]
    // public IActionResult GetSecureCustomerData()
    // {
    //     return Ok("Tebrikler. Customer verisine ulaşabiliyorsunuz.");
    // }
}
