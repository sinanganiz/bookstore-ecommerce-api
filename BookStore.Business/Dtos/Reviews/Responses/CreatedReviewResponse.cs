namespace BookStore.Business.Dtos.Reviews;

public class CreatedReviewResponse
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }

    public string AppUserId { get; set; } = null!;
    public int BookId { get; set; }
}