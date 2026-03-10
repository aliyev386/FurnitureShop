using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Product
{
    public class CreateProductDto
    {
        public decimal Price { get; set; }
        public decimal? PriceExtra { get; set; }
        public string Label { get; set; }
        public string Material { get; set; }
        public List<string> Colors { get; set; }
        public List<string> Images { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public List<ProductTranslationDto> Translations { get; set; }
    }
}
