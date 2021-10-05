using MediatR;
using System;
using System.Collections.Generic;

namespace ApplicationDomainServices.Queries.ItemQueries
{
    public class ReadItemTypesQuery : IRequest<IEnumerable<Tuple<string, int>>>
    {

    }
}
