using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.AccountQueries;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.AccountHandlers
{
    public class ReadAccountByPropQueryHandler : IRequestHandler<ReadAccountByPropQuery, AccountDto>
    {
        private readonly IRepository<Account> _accountRepo = default;
        private readonly IMapper _mapper = default;
        public ReadAccountByPropQueryHandler(IRepository<Account> accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }
        public async Task<AccountDto> Handle(ReadAccountByPropQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepo.GetByIdAsync(request.AccountId);
            return _mapper.Map<AccountDto>(account);
        }
    }
}
