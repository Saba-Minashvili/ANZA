using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.PhotoQueiries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.PhotoHandlers
{
    public class ReadAccountPhotoQueryHandler : IRequestHandler<ReadAccountPhotoQuery, string>
    {
        private readonly IRepository<Account> _accountRepo = default;
        public ReadAccountPhotoQueryHandler(IRepository<Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public async Task<string> Handle(ReadAccountPhotoQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepo.GetByIdAsync(request.AccountId);
            var photo = account.AccountPhoto;
            return photo;
        }
    }
}
