﻿
namespace BookStore.Business.Dtos.Auth.Requests;

public class RegisterAppUserRequest
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
