
using BookStore.Business.Dtos.Reviews;
using BookStore.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;
    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<ReviewResponse>> GetById(int id)
    {
        var response = await _reviewService.GetReviewByIdAsync(id);
        return Ok(response);
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ReviewResponse>>> List()
    {
        var response = await _reviewService.GetAllReviewsAsync();
        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreatedReviewResponse>> Create(CreateReviewRequest request)
    {
        var response = await _reviewService.AddReviewAsync(request);
        return Ok(response);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<UpdatedReviewResponse>> Update(int id, UpdateReviewRequest request)
    {
        var response = await _reviewService.UpdateReviewAsync(id, request);
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reviewService.DeleteReviewAsync(id);
        return NoContent();
    }

}