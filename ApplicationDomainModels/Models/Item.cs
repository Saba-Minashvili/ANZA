using ApplicationDomainModels.Enums;

namespace ApplicationDomainModels.Models
{
    public class Item : BaseEntity
    {
        public string ItemPhoto { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public MaterialType MaterialType { get; set; }
        public DesignedFor DesignedFor { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
