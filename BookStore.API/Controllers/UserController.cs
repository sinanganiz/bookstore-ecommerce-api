
using BookStore.Business.Constants;
using BookStore.Business.Dtos.Users;
using BookStore.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = Roles.Admin)]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpGet("get/{id}")]
    public async Task<ActionResult<UserResponse>> GetUserById(string id)
    {
        var response = await _userService.GetUserByIdAsync(id);
        return Ok(response);
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<UserResponse>>> ListUsers([FromQuery] string userType)
    {
        // Customer | Admin
        var response = await _userService.ListUsersAsync(userType);
        return Ok(response);
    }


    [HttpPost("create")]
    public async Task<ActionResult<CreatedUserResponse>> Create(CreateUserRequestWithPassword request, [FromQuery] string userType)
    {
        var response = await _userService.CreateAsync(request, userType);
        return Ok(response);
    }


    [HttpPut("update/{id}")]
    public async Task<ActionResult<UpdatedUserResponse>> Update(string id, UpdateUserRequest updateUserRequest)
    {
        var response = await _userService.UpdateAsync(id, updateUserRequest);
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _userService.DeleteAsync(id);
        if (response)
        {
            return NoContent();
        }

        return BadRequest();
    }
}