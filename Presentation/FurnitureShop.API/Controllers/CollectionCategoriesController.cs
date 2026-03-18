using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using FurnitureShop.Persistence.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.API.Controllers;

[Route("api/collection-category")]
[ApiController]
public class CollectionCategoriesController : ControllerBase
{
    private readonly ICollectionCategoryService _collectionCategoryService;
    private readonly ICollectionService _collectionService;

    public CollectionCategoriesController(ICollectionCategoryService collectionCategoryService)
    {
        _collectionCategoryService = collectionCategoryService;
    }
    [HttpGet("by-category/{categoryId}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var data = await _collectionService.GetByCategoryIdAsync(categoryId);
        return Ok(data);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string lang = "az")
    {
        var categories = await _collectionCategoryService.GetAllWithTranslationsAsync(lang);
        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, [FromQuery] string lang = "az")
    {
        var category = await _collectionCategoryService.GetByIdAsync(id, lang);
        return category != null ? Ok(category) : NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CollectionCategory category)
    {
        await _collectionCategoryService.CreateAsync(category);
        return Ok(new { id = category.Id });
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _collectionCategoryService.DeleteAsync(id);
        return Ok(new { message = "Deleted successfully" });
    }
}