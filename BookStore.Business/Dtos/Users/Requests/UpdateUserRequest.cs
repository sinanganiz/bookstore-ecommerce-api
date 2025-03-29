namespace BookStore.Business.Dtos.Users;

public class UpdateUserRequest
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public string? PhoneNumber { get; set; }

}