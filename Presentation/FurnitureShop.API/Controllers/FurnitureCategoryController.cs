using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FurnitureCategory category)
    {
        await _furnitureCategoryService.CreateAsync(category);
        return Ok(new { message = "Furniture category created successfully", id = category.Id });
    }
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] FurnitureCategory category)
    {
        await _furnitureCategoryService.UpdateAsync(category);
        return Ok("Updated successfully");
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromBody] FurnitureCategory category)
    {
        await _furnitureCategoryService.DeleteAsync(category);
        return Ok("Deleted successfully");
    }
}