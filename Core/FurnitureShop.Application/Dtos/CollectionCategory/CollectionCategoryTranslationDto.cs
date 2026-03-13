using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.CollectionCategory
{
    public class CollectionCategoryTranslationDto
    {
        public string Language { get; set; }   // "az", "en", "ru"
        public string Name { get; set; }
    }
}
