
using BookStore.Business.Constants;
using BookStore.Business.Dtos;
using BookStore.Business.Dtos.Requests;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly TokenService _tokenService;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<string?> Register(RegisterAppUserRequest model)
    {
        var user = new AppUser { Name = model.Name, Surname = model.Surname, UserName = model.UserName, Email = model.Email, EmailConfirmed = true };
       
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded) return null;

        await _userManager.AddToRoleAsync(user, Roles.Customer);

        var token = await _tokenService.GenerateToken(user);
        return token;
    }

    public async Task<string?> Login(LoginAppUserRequest model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) return null;

        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded) return null;

        var token = await _tokenService.GenerateToken(user);
        return token;
    }
}
