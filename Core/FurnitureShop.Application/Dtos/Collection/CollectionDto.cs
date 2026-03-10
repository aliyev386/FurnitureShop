using FurnitureShop.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Collection;

public class CollectionDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public List<ProductDto> Products { get; set; }
}
