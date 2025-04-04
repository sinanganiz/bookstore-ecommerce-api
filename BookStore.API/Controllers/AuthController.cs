using Microsoft.AspNetCore.Mvc;
using BookStore.Business.Services;
using BookStore.Business.Dtos.Auth.Requests;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAppUserRequest model)
    {
        var token = await _authService.Login(model);
        if (token == null) return Unauthorized("Geçersiz e-posta veya şifre!");
        return Ok(new { Token = token });
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterAppUserRequest model)
    {
        var token = await _authService.Register(model);
        if (token == null) return BadRequest("Registration failed");
        return Ok(new { Token = token });
    }
}
