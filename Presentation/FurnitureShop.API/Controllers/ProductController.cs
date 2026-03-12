using Microsoft.AspNetCore.Mvc;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;

namespace FurnitureShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController([FromBody] IProductService productService) => _productService = productService;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string lang = "az")
    {
        var products = await _productService.SearchAsync("", lang);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromBody] int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        await _productService.CreateAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}