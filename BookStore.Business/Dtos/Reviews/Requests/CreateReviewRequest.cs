namespace BookStore.Business.Dtos.Reviews;

public class CreateReviewRequest
{
    public string? Comment { get; set; }
    public int Rating { get; set; }
    public string AppUserId { get; set; } = null!;
    public int BookId { get; set; }
}