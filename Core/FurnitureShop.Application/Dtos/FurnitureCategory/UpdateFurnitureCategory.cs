using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.FurnitureCategory
{
    public class UpdateFurnitureCategory
    {
        public string ImageUrl { get; set; }
        public List<FurnitureCategoryTranslationDto> Translations { get; set; }
    }

}
