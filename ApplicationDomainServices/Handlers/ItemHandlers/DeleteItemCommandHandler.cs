using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Commands.ProductCommands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.ProductHandlers
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly IRepository<Item> _itemRepo = default;

        public DeleteItemCommandHandler(IRepository<Item> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepo.GetByIdAsync(request.ItemId);
            return await _itemRepo.DeleteAsync(item);
        }
    }
}
