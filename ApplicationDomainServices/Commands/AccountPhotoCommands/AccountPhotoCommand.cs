using MediatR;

namespace ApplicationDomainServices.Commands
{
    public class AccountPhotoCommand : IRequest<bool>
    {
        public int AccountId { get; set; }
        public string FileName { get; set; }
    }
}
