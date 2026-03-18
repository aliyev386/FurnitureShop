using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace FurnitureShop.API.Controllers;

[Route("api/furniture-categories")]
[ApiController]
public class FurnitureCategoriesController : ControllerBase
{
    private readonly IFurnitureCategoryService _furnitureCategoryService;

    [JsonIgnore]
    public FurnitureCategory FurnitureCategory { get; set; }

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
        return Ok(new { message = "Updated successfully" });
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] FurnitureCategory category)
    {
        await _furnitureCategoryService.DeleteAsync(category);
        return Ok(new { message = "Deleted successfully" });
    }
}