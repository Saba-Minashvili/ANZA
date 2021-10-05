using ApplicationDomainModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationDomainDtos.Dtos
{
    public class ShippingAddressDto:BaseEntity
    {
        public int? AddressId { get; set; }
        public int? ContactId { get; set; }
        [ForeignKey("ContactId")]
        public Contact ContactToUser { get; set; }
        [ForeignKey("AddressId")]
        public Address UserAddress { get; set; }
    }
}
