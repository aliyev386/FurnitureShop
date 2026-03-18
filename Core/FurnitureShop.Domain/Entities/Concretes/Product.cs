using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Domain.Entities.Concretes.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;
public class Product:BaseEntity
{
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int FurnitureCategoryId { get; set; }

    [JsonIgnore]
    public FurnitureCategory FurnitureCategory { get; set; }
    public string Material { get; set; }
    public string  Colors { get; set; }       
    public bool IsFeatured { get; set; }
    public int DisplayOrder { get; set; }
    public string ImagesUrl { get; set; }
    public string Label { get; set; }
    public decimal? PriceExtra { get; set; }
    public int Rating { get; set; }
    public ICollection<ProductTranslation> Translations { get; set; }


}