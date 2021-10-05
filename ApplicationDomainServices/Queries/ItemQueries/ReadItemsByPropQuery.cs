using ApplicationDomainDtos.Dtos;
using MediatR;
using System.Collections.Generic;

namespace ApplicationDomainServices.Queries.ProductQueries
{
    public class ReadItemsByPropQuery : IRequest<IEnumerable<ItemDto>>
    {
        public string ItemType { get; set; }
        public double ItemPrice { get; set; }
        public string ItemName { get; set; }
    }
}
