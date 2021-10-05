using ApplicationDomainModels.Enums;
using ApplicationDomainModels.Models;

namespace ApplicationDomainDtos.Dtos
{
    public class ItemDto : BaseEntity
    {
        public string ItemPhoto { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public DesignedFor DesignedFor { get; set; }
        public double Price { get; set; }
    }
}
