using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;


public enum DiscountType
{
    Percent = 1,
    Fixed = 2
}

public enum DiscountStatus
{
    Active = 1,
    Expired = 2,
    Passive = 3
}

public class DiscountCode
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;

    public DiscountType Type { get; set; }
    public decimal Value { get; set; }
    public decimal? MinOrderAmount { get; set; }
    public int? MaxUses { get; set; }
    public int UsedCount { get; set; } = 0;
    public DateTime? ExpiresAt { get; set; }
    public DiscountStatus Status { get; set; } = DiscountStatus.Active;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}