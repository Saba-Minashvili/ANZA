using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Commands.AccountCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.AccountHandlers
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, bool>
    {
        private readonly IRepository<Account> _accountRepo = default;
        public DeleteAccountCommandHandler(IRepository<Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepo.GetByIdAsync(request.AccountId);
            return await _accountRepo.DeleteAsync(account);
        }
    }
}
