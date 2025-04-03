namespace BookStore.Business.Dtos.Reviews;

public class UpdatedReviewResponse
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}