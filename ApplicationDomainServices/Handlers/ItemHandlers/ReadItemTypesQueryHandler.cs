using ApplicationDomainModels.Enums;
using ApplicationDomainServices.Queries.ItemQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.ItemHandlers
{
    public class ReadItemTypesQueryHandler : IRequestHandler<ReadItemTypesQuery, IEnumerable<Tuple<string, int>>>
    {
        public async Task<IEnumerable<Tuple<string, int>>> Handle(ReadItemTypesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<Tuple<string, int>>();
            var i = 1;

            foreach (var type in Enum.GetNames(typeof(ItemType)))
            {
                for (var typeId = 1; typeId <= (Enum.GetNames(typeof(ItemType))).Length; typeId++)
                {
                    if (i == typeId)
                    {
                        result.Add(new Tuple<string, int>(type, typeId));
                    }
                }

                i++;
            }

            return result;
        }
    }
}
