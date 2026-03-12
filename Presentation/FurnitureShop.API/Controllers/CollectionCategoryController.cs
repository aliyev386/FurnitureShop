using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
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
    public async Task<IActionResult> GetAll(string lang = "az")
    {
        var categories = await _collectionCategoryService.GetAllWithTranslationsAsync(lang);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, string lang = "az")
    {
        var category = await _collectionCategoryService.GetByIdAsync(id, lang);
        return category != null ? Ok(category) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CollectionCategory category)
    {
        await _collectionCategoryService.CreateAsync(category);
        return Ok(new { message = "Collection category created successfully", id = category.Id });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _collectionCategoryService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}