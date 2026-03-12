using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService) => _orderService = orderService;

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(Order order)
    {
        await _orderService.CreateOrderAsync(order);
        return Ok(new { Message = "Sifariş qəbul edildi", OrderId = order.Id });
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserOrders(string userId)
        => Ok(await _orderService.GetUserOrdersAsync(userId));
}