using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Domain.Entities.Concretes.Translation;

namespace FurnitureShop.Domain.Entities.Concretes;

public class CollectionCategory:BaseEntity
{
    public ICollection<CollectionCategoryTranslation> Translations { get; set; }
    public ICollection<Collection> Collections { get; set; }

}