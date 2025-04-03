namespace BookStore.Business.Dtos.Reviews;

public class UpdateReviewRequest
{
    public string? Comment { get; set; }
    public int Rating { get; set; }
}