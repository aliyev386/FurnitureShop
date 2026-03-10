using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.FurnitureCategory;

public class FurnitureCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }       // aktiv dil icin
    public string ImageUrl { get; set; }
}
