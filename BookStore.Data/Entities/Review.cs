namespace BookStore.Data.Entities;

public class Review
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string AppUserId { get; set; } = null!;
    public AppUser? AppUser { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; }
}