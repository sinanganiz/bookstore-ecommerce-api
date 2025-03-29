
using AutoMapper;
using BookStore.Business.Dtos;
using BookStore.Business.Dtos.Categories;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class CategoryService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryResponse> GetCategoryById(int id)
    {
        try
        {
            if (id < 0) throw new ArgumentException("Geçersiz id");

            var category = await _context.Categories.FindAsync(id);

            if (category == null) throw new Exception("Kategori bulunamadı");

            var categoryResponse = _mapper.Map<CategoryResponse>(category);

            return categoryResponse;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<CategoryResponse>> List()
    {
        try
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryResponses = _mapper.Map<List<CategoryResponse>>(categories);
            return categoryResponses;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    public async Task<CreatedCategoryResponse> Create(CreateCategoryRequest request)
    {
        try
        {
            var category = _mapper.Map<Category>(request);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<CreatedCategoryResponse>(category);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<UpdatedCategoryResponse> UpdateAsync(int id, UpdateCategoryRequest request)
    {
        try
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) throw new Exception("Kategori bulunamadı!");

            _mapper.Map(request, category);

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<UpdatedCategoryResponse>(category);

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            if (id < 0) throw new ArgumentException();
            
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new Exception("Kategori bulunamadı!");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }


}
