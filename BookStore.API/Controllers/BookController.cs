using Microsoft.AspNetCore.Mvc;

using BookStore.Business.Dtos;
using BookStore.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BookStore.Business.Constants;

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
