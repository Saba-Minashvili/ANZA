using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Commands.ProductCommands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.ProductHandlers
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, bool>
    {
        private readonly IRepository<Item> _itemRepo = default;
        private readonly IMapper _mapper = default;

        public AddItemCommandHandler(IRepository<Item> itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request);
            return await _itemRepo.CreateAsync(item);
        }
    }
}
