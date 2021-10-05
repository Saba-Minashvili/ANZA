using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDomainModels.Models
{
    public class Account : BaseEntity
    {
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        public string LastName { get; set; }
        [Required]
        [StringLength(26, ErrorMessage = "The Email value cannot exceed 16 characters. ", MinimumLength = 15)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "The Email value cannot exceed 16 characters.", MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
        public int? ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public ShippingAddress UserAddress { get; set; }
        public string AccountPhoto { get; set; }
        public List<LikedItem> LikeItemsList { get; set; } = new List<LikedItem>();
    }
}
