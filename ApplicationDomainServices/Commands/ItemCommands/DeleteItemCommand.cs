using MediatR;

namespace ApplicationDomainServices.Commands.ProductCommands
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public int ItemId { get; set; }
    }
}
