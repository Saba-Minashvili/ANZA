using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.PhotoQueiries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.PhotoHandlers
{
    public class ReadItemPhotoQueryHandler : IRequestHandler<ReadItemPhotoQuery, string>
    {
        private readonly IRepository<Item> _itemRepo = default;
        public ReadItemPhotoQueryHandler(IRepository<Item> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public async Task<string> Handle(ReadItemPhotoQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepo.GetByIdAsync(request.ItemId);
            var photo = item.ItemPhoto;
            return photo;
        }
    }
}
