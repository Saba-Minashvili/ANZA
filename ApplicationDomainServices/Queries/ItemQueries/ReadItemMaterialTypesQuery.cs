using MediatR;
using System.Collections.Generic;

namespace ApplicationDomainServices.Queries.ItemQueries
{
    public class ReadItemMaterialTypesQuery : IRequest<List<string>>
    {
        public int ItemTypeId { get; set; }
    }
}
