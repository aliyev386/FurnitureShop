using FurnitureShop.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Order
{
    public class CreateOrderDto
    {
        public OrderType Type { get; set; }
        public string DeliveryAddress { get; set; }
        public string Notes { get; set; }        
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
        public string GuestEmail { get; set; }
        public List<CreateOrderItemDto> Items { get; set; }

    }
}
