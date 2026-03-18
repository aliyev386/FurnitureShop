using FurnitureShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;


public class Wishlist
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public AppUser User { get; set; } = null!;
    public ICollection<WishlistItem> Items { get; set; } = new List<WishlistItem>();
}
