using AutoMapper;
using BookStore.Business.Constants;
using BookStore.Business.Dtos.Users;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class UserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserResponse> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        var response = _mapper.Map<UserResponse>(user);
        return response;
    }

    public async Task<List<UserResponse>> ListUsersAsync(string userType)
    {
        IList<AppUser> users = new List<AppUser>();
        if (userType == Roles.Admin)
        {
            users = await _userManager.GetUsersInRoleAsync(Roles.Admin);
        }
        else if (userType == Roles.Customer)
        {
            users = await _userManager.GetUsersInRoleAsync(Roles.Customer);
        }
        else
        {
            throw new ArgumentException("Unknown usertype");
        }

        var response = _mapper.Map<List<UserResponse>>(users);
        return response;
    }
    public async Task<CreatedUserResponse> CreateAsync(CreateUserRequestWithPassword request, string userType)
    {
        var user = _mapper.Map<AppUser>(request);

        await _userManager.CreateAsync(user, request.Password);
        await _userManager.AddToRoleAsync(user, userType);

        var response = _mapper.Map<CreatedUserResponse>(user);

        return response;
    }

    public async Task<UpdatedUserResponse> UpdateAsync(string id, UpdateUserRequest updateUserRequest)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            throw new ArgumentException($"User with ID {id} not found.");
        }

        _mapper.Map(updateUserRequest, user);

        await _userManager.UpdateAsync(user);

        var response = _mapper.Map<UpdatedUserResponse>(user);
        return response;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            throw new ArgumentException($"User with ID {id} not found.");
        }

        await _userManager.DeleteAsync(user);

        return true;
    }


}
