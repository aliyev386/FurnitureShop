using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CollectionCategoriesController : ControllerBase
{
    private readonly ICollectionCategoryService _collectionCategoryService;

    public CollectionCategoriesController(ICollectionCategoryService collectionCategoryService)
    {
        _collectionCategoryService = collectionCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromBody] string lang = "az")
    {
        var categories = await _collectionCategoryService.GetAllWithTranslationsAsync(lang);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromBody] int id, string lang = "az")
    {
        var category = await _collectionCategoryService.GetByIdAsync(id, lang);
        return category != null ? Ok(category) : NotFound();
    }
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CollectionCategory category)
    {
        await _collectionCategoryService.CreateAsync(category);
        return Ok(new { message = "Collection category created successfully", id = category.Id });
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromBody] int id)
    {
        await _collectionCategoryService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}