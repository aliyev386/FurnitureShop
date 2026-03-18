using FurnitureShop.Application.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.API.Controllers;

[Route("api/collection")]
[ApiController]
public class CollectionController : ControllerBase
{
    private readonly ICollectionService _collectionService;
    private readonly ICollectionCategoryService _categoryService;

    public CollectionController(ICollectionService collectionService, ICollectionCategoryService categoryService)
    {
        _collectionService = collectionService;
        _categoryService = categoryService;
    }
    [HttpGet("by-category/{categoryId}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var data = await _collectionService.GetByCategoryIdAsync(categoryId);
        return Ok(data);
    }
    [HttpGet]
    public async Task<IActionResult> GetCollections() => Ok(await _collectionService.GetAllAsync());
    
    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories([FromBody] string lang = "az")
        => Ok(await _categoryService.GetAllWithTranslationsAsync(lang));
}