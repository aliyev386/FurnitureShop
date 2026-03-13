using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.CollectionCategory
{
    public class UpdateCollectionCategoryDto
    {
        public string ImageUrl { get; set; }
        public List<CollectionCategoryTranslationDto> Translations { get; set; }
    }
}
