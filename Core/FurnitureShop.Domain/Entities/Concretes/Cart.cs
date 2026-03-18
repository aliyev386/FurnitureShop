using FurnitureShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;


public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public AppUser User { get; set; } = null!;
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}
