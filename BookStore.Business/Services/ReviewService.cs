using AutoMapper;
using BookStore.Business.Dtos.Reviews;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;
public class ReviewService
{
    private readonly IRepository<Review, int> _repository;
    private readonly IMapper _mapper;

    public ReviewService(IRepository<Review, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewResponse>> GetAllReviewsAsync()
    {
        var reviews = await _repository.GetAllAsync();
        var reviewResponses = _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
        return reviewResponses;
    }

    public async Task<ReviewResponse> GetReviewByIdAsync(int id)
    {
        var review = await _repository.GetByIdAsync(id);
        var response = _mapper.Map<ReviewResponse>(review);
        return response;
    }

    public async Task<CreatedReviewResponse> AddReviewAsync(CreateReviewRequest request)
    {
        var review = _mapper.Map<Review>(request);
        var addedReview = await _repository.AddAsync(review);

        var addedReviewResponse = _mapper.Map<CreatedReviewResponse>(addedReview);
        return addedReviewResponse;
    }

    public async Task<UpdatedReviewResponse> UpdateReviewAsync(int id, UpdateReviewRequest request)
    {
        var review = await _repository.GetByIdAsync(id);
        _mapper.Map(request, review);
        var updatedReview = await _repository.UpdateAsync(review);

        var updatedReviewResponse = _mapper.Map<UpdatedReviewResponse>(updatedReview);
        return updatedReviewResponse;
    }

    public async Task DeleteReviewAsync(int id)
    {
        var review = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(review);
    }

}
