
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
        try
        {
            var categoryResponse = await _categoryService.GetCategoryById(id);
            return Ok(categoryResponse);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception:", ex); // Add logger
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<CategoryResponse>>> List()
    {
        try
        {
            var categoryResponses = await _categoryService.List();
            return Ok(categoryResponses);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreatedCategoryResponse>> Create(CreateCategoryRequest request)
    {
        try
        {
            var response = await _categoryService.Create(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<UpdatedCategoryResponse>> Update(int id, UpdateCategoryRequest request)
    {
        try
        {
            var response = await _categoryService.UpdateAsync(id, request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent(); // 204 status code is the standard response for successful DELETE
    }

}