using MediatR;

namespace ApplicationDomainServices.Commands.AccountCommands
{
    public class CreateAccountCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string AccountImage { get; set; }
    }
}
