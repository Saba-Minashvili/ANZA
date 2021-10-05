using ApplicationDomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomainDtos.Dtos
{
    public class ContactDto:BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
