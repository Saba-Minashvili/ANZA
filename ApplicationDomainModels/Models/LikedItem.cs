using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDomainModels.Models
{
    public class LikedItem : BaseEntity
    {
        public Item Item { get; set; }
        public int? AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
