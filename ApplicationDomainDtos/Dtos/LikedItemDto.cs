using ApplicationDomainModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDomainDtos.Dtos
{
    public class LikedItemDto : BaseEntity
    {
        public ItemDto Item { get; set; }
        public int? AccountId { get; set; }
        [ForeignKey("AccountId")]
        public AccountDto Account { get; set; }
    }
}
