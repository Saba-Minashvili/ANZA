using ApplicationDomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomainDtos.Dtos
{
    public class AddressDto:BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public int ZipCode { get; set; }
    }
}
