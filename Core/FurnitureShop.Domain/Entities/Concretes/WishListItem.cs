using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;


public class WishlistItem
{
    public int Id { get; set; }
    public int WishlistId { get; set; }

    public int? ProductId { get; set; }
    public int? CollectionId { get; set; }

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    public Wishlist Wishlist { get; set; } = null!;
    public Product? Product { get; set; }
    public Collection? Collection { get; set; }
}
