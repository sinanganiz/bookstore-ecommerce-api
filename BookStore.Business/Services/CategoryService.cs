
using AutoMapper;
using BookStore.Business.Dtos;
using BookStore.Business.Dtos.Categories;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class CategoryService
{
    private readonly IRepository<Category, int> _repository;
    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category, int> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
    {
        var categories = await _repository.GetAllAsync();
        var categoryResponses = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        return categoryResponses;
    }

    public async Task<CategoryResponse> GetCategoryByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        var categoryResponse = _mapper.Map<CategoryResponse>(category);
        return categoryResponse;
    }


    public async Task<CreatedCategoryResponse> AddCategoryAsync(CreateCategoryRequest request)
    {
        var category = _mapper.Map<Category>(request);
        var addedCategory = await _repository.AddAsync(category);

        var createdBookResponse = _mapper.Map<CreatedCategoryResponse>(addedCategory);
        return createdBookResponse;
    }

    public async Task<UpdatedCategoryResponse> UpdateCategoryAsync(int id, UpdateCategoryRequest request)
    {
        var category = await _repository.GetByIdAsync(id);
        _mapper.Map(request, category);
        var updatedCategory = await _repository.UpdateAsync(category);

        var response = _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
        return response;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(category);
    }


}
