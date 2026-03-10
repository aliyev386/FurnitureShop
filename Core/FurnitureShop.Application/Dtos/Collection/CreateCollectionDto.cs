using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Collection
{
    public class CreateCollectionDto
    {
        public string CoverImageUrl { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int CategoryId { get; set; }
        public int DisplayOrder { get; set; }
        public List<int> ProductIds { get; set; }   // hansi productlar
        public List<CollectionTranslationDto> Translations { get; set; }

    }
}
