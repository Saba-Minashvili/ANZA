using ApplicationDomainDtos.Dtos;
using MediatR;
using System.Collections.Generic;

namespace ApplicationDomainServices.Queries.ProductQueries
{
    public class ReadAllItemQuery : IRequest<IEnumerable<ItemDto>>
    {

    }
}
