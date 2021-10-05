using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.ProductQueries;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.ProductHandlers
{
    public class ReadItemsByPropQueryHandler : IRequestHandler<ReadItemsByPropQuery, IEnumerable<ItemDto>>
    {
        private readonly IRepository<Item> _itemRepo = default;
        private readonly IMapper _mapper = default;

        public ReadItemsByPropQueryHandler(IRepository<Item> itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ItemDto>> Handle(ReadItemsByPropQuery request, CancellationToken cancellationToken)
        {
            var filteredColl = new List<Item>();
            var allItems = await _itemRepo.ReadAsync();
            if (request.ItemName != null && request.ItemType == null)
            {
                foreach (var item in allItems)
                {
                    if (item.Name.ToLower() == request.ItemName.ToLower())
                    {
                        filteredColl.Add(item);
                    }
                }
            }
            else if (request.ItemName == null && request.ItemType != null)
            {
                foreach (var item in allItems)
                {
                    if ((item.Type).ToString() == request.ItemType)
                    {
                        filteredColl.Add(item);
                    }
                }
            }
            else if (request.ItemPrice > 0 && request.ItemName == null && request.ItemType == null)
            {
                foreach (var item in allItems)
                {
                    if (request.ItemPrice == item.Price)
                    {
                        filteredColl.Add(item);
                    }
                }
            }
            else
            {
                return new List<ItemDto>();
            }

            return _mapper.Map<IEnumerable<ItemDto>>(filteredColl);
        }
    }
}
