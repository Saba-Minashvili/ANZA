using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomainModels.Models
{
    public class Address:BaseEntity
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Apartment { get; set; }
        [Required]
        [MaxLength(4, ErrorMessage = "The Zip Code value cannot exceed 4 characters.")]
        [MinLength(4)]
        public int ZipCode { get; set; }
    }
}
