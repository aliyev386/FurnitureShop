namespace FurnitureShop.Application.Dtos.Product
{
    public class ProductTranslationDto
    {
        public string Language { get; set; }   // "az", "en", "ru"
        public string Name { get; set; }
        public string Description { get; set; }
    }
}