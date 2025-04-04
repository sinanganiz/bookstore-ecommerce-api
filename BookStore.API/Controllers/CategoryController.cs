
using BookStore.Business.Dtos.Categories;
using BookStore.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<CategoryResponse>> GetById(int id)
    {
        var categoryResponse = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(categoryResponse);
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<CategoryResponse>>> List()
    {
        var categoryResponses = await _categoryService.GetAllCategoriesAsync();
        return Ok(categoryResponses);
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreatedCategoryResponse>> Create(CreateCategoryRequest request)
    {

        var response = await _categoryService.AddCategoryAsync(request);
        return Ok(response);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<UpdatedCategoryResponse>> Update(int id, UpdateCategoryRequest request)
    {

        var response = await _categoryService.UpdateCategoryAsync(id, request);
        return Ok(response);

    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }

}