using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers
{
    public class AddMaterialTypesCommandHandler : IRequestHandler<AddMaterialTypesCommand, bool>
    {
        private readonly IRepository<MaterialType> _materialRepo = default;
        private readonly IMapper _mapper = default;
        public AddMaterialTypesCommandHandler(IRepository<MaterialType> materialRepo, IMapper mapper)
        {
            _materialRepo = materialRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AddMaterialTypesCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<MaterialType>(request);
            return await _materialRepo.CreateAsync(result);
        }
    }
}
