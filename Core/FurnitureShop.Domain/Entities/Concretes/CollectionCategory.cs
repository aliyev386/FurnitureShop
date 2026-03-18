using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Domain.Entities.Concretes.Translation;

namespace FurnitureShop.Domain.Entities.Concretes;

public class CollectionCategory:BaseEntity
{
    public int Id { get; set; }
    public int CollectionCategoryId { get; set; }
    public string ImagesUrl { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<CollectionCategoryTranslation> Translations { get; set; }
    public ICollection<Collection> Collections { get; set; }

}