using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.ItemQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers
{
    public class ReadMaterialTypesQueryHandler : IRequestHandler<ReadItemMaterialTypesQuery, List<string>>
    {
        private readonly IRepository<MaterialType> _materialRepo = default;

        public ReadMaterialTypesQueryHandler(IRepository<MaterialType> materialRepo)
        {
            _materialRepo = materialRepo;
        }
        public async Task<List<string>> Handle(ReadItemMaterialTypesQuery request, CancellationToken cancellationToken)
        {
            if (request.ItemTypeId != 0)
            {
                var types = await _materialRepo.ReadAsync();
                var result = new List<string>();
                foreach (var item in types)
                {
                    if (item.ItemTypeId == request.ItemTypeId)
                    {
                        result.Add(item.MaterialTypeName);
                    }
                }

                return result;
            }
            else
            {
                throw new System.Exception();
            }
        }
    }
}
