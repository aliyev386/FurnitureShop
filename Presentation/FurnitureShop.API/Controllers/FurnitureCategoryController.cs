using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FurnitureCategoriesController : ControllerBase
{
    private readonly IFurnitureCategoryService _furnitureCategoryService;

    public FurnitureCategoriesController(IFurnitureCategoryService furnitureCategoryService)
    {
        _furnitureCategoryService = furnitureCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _furnitureCategoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FurnitureCategory category)
    {
        await _furnitureCategoryService.CreateAsync(category);
        return Ok(new { message = "Furniture category created successfully", id = category.Id });
    }

    [HttpPut]
    public async Task<IActionResult> Update(FurnitureCategory category)
    {
        await _furnitureCategoryService.UpdateAsync(category);
        return Ok("Updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _furnitureCategoryService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}