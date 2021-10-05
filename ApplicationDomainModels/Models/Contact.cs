using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomainModels.Models
{
    public class Contact:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(9, ErrorMessage = "The Number value cannot exceed 9 characters.", MinimumLength = 9)]
        public string PhoneNumber { get; set; }
    }
}
