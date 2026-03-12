using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;

public class Order:BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public decimal TotalPrice { get; set; }
    public string Notes { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<OrderItem> Items { get; set; }
}
