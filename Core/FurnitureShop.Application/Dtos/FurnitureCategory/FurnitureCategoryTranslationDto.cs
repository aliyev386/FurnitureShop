using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.FurnitureCategory;

public class FurnitureCategoryTranslationDto
{
    public string Language { get; set; }   // "az", "en", "ru"
    public string Name { get; set; }
}