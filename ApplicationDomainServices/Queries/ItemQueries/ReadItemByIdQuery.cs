using ApplicationDomainDtos.Dtos;
using MediatR;

namespace ApplicationDomainServices.Queries.ItemQueries
{
    public class ReadItemByIdQuery : IRequest<ItemDto>
    {
        public int ItemId { get; set; }
    }
}
