using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.ProductQueries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.ProductHandlers
{
    public class ReadAllItemQueryHandler : IRequestHandler<ReadAllItemQuery, IEnumerable<ItemDto>>
    {
        private readonly IRepository<Item> _itemRepo = default;
        private readonly IMapper _mapper = default;

        public ReadAllItemQueryHandler(IRepository<Item> itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ItemDto>> Handle(ReadAllItemQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepo
                .Get()
                .ToListAsync();
            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }
    }
}
