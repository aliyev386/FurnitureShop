using FurnitureShop.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Order
{
    public class CreateOrderItemDto
    {
        public int? ProductId { get; set; }
        public int? CollectionId { get; set; }
        public string SelectedColor { get; set; }
        public string SelectedSize { get; set; }
        public int Quantity { get; set; } = 1;
        public string CustomDescription { get; set; }
    }
}
