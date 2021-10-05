using MediatR;

namespace ApplicationDomainServices.Commands.ProductCommands
{
    public class ItemPictureCommand : IRequest<bool>
    {
        public int ItemId { get; set; }
        public string FileName { get; set; }
    }
}
