using ApplicationDomainDtos.Dtos;
using MediatR;

namespace ApplicationDomainServices.Commands.ProductCommands
{
    public class UpdateItemCommand : IRequest<bool>
    {
        public int ItemId { get; set; }
        public ItemDto Item { get; set; }
    }
}
