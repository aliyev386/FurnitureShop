namespace FurnitureShop.Domain.Entities.Concretes.Translation
{
    public class HeroTranslation
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string BadgeText { get; set; }

        public int Id { get; set; }
        public int HeroSectionId { get; set; }
        public string Lang { get; set; }     
        public HeroSection heroSection { get; set; }
    }
}