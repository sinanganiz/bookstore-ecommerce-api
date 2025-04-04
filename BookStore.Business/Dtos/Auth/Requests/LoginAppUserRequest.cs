
namespace BookStore.Business.Dtos.Auth.Requests;

public class LoginAppUserRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

}
