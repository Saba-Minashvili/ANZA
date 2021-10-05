using ApplicationDomainModels.Models;

namespace ApplicationDomainDtos.Dtos
{
    public class AccountDto : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string AccountPhoto { get; set; }
    }
}
