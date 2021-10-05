using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Commands.AccountCommands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.AccountHandlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, bool>
    {
        private readonly IRepository<Account> _accountRepo = default;
        private readonly IMapper _mapper = default;
        public CreateAccountCommandHandler(IRepository<Account> accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request);
            return await _accountRepo.CreateAsync(account);
        }
    }
}
