using FurnitureShop.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
        public string GuestEmail { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
