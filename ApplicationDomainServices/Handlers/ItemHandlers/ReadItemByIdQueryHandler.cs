using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.ItemQueries;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.ProductHandlers
{
    public class ReadItemByIdQueryHandler : IRequestHandler<ReadItemByIdQuery, ItemDto>
    {
        private readonly IRepository<Item> _itemRepo = default;
        private readonly IMapper _mapper = default;

        public ReadItemByIdQueryHandler(IRepository<Item> itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }
        public async Task<ItemDto> Handle(ReadItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepo.GetByIdAsync(request.ItemId);
            return _mapper.Map<ItemDto>(item);
        }
    }
}
