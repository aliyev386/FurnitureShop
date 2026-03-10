using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Order
{
    public class OrderItemDto 
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string SelectedColor { get; set; }
        public string SelectedSize { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string CustomDescription { get; set; }
    }
}
