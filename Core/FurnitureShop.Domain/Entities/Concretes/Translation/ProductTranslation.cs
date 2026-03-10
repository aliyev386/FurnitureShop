namespace FurnitureShop.Domain.Entities.Concretes.Translation;

public class ProductTranslation
{
    public int Id { get; set; }
    public int ProductId { get; set; }      
    public string Lang { get; set; }        // "az", "en", "ru"
    public string Title { get; set; }
    public string Description { get; set; }

    public Product Product { get; set; }

}