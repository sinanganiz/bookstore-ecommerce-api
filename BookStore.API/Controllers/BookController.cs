using Microsoft.AspNetCore.Mvc;

using BookStore.Business.Dtos;
using BookStore.Business.Services;

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
    public ActionResult<List<BookResponse>> List()
    {
        List<BookResponse> bookResponses = _bookService.ListBooks();

        return bookResponses;
    }

}
