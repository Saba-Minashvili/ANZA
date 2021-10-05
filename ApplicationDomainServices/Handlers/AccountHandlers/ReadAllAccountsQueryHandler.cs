using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using ApplicationDomainServices.Queries.AccountQuery;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomainServices.Handlers.AccountHandlers
{
    public class ReadAllAccountsQueryHandler : IRequestHandler<ReadAllAccountsQuery, IEnumerable<AccountDto>>
    {
        private readonly IRepository<Account> _accountRepo = default;
        private readonly IMapper _mapper = default;
        public ReadAllAccountsQueryHandler(IRepository<Account> accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AccountDto>> Handle(ReadAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepo
                .Get()
                .ToListAsync();
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }
    }
}
