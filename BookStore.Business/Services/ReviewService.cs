using AutoMapper;
using BookStore.Business.Dtos.Reviews;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;
public class ReviewService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ReviewService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ReviewResponse> GetByIdAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        var response = _mapper.Map<ReviewResponse>(review);

        return response;
    }
    public async Task<List<ReviewResponse>> ListAsync()
    {
        var reviews = await _context.Reviews.ToListAsync();

        var reviewResponses = _mapper.Map<List<ReviewResponse>>(reviews);

        return reviewResponses;
    }

    public async Task<CreatedReviewResponse> CreateAsync(CreateReviewRequest request)
    {
        var review = _mapper.Map<Review>(request);

        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<CreatedReviewResponse>(review);

        return response;
    }

    public async Task<UpdatedReviewResponse> UpdateAsync(int id, UpdateReviewRequest request)
    {
        var review = await _context.Reviews.FindAsync(id);

        _mapper.Map(request, review);

        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<UpdatedReviewResponse>(review);
        return response;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();

        return true;
    }

}
