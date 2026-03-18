using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Domain.Entities.Enums;
using FurnitureShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;
public enum PaymentMethod
    {
        CashOnDelivery = 1,
        Card = 2,
        BankTransfer = 3
    }

    public enum PaymentStatus
    {
        Pending = 1,
        Paid = 2,
        Failed = 3,
        Refunded = 4
    }
public class Order:BaseEntity
{
    

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public int? DiscountCodeId { get; set; }
    public DiscountCode? DiscountCode { get; set; }

    public decimal ShippingCost { get; set; } = 0;
    public decimal DiscountAmount { get; set; } = 0;

    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CashOnDelivery;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    public string? Note { get; set; }
    public string Lang { get; set; } = "AZ";
    public string UserId { get; set; }
    public AppUser? User { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public decimal TotalPrice { get; set; }
    public string Notes { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<OrderItem> Items { get; set; }
}
