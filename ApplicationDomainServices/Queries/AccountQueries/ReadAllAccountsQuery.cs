using ApplicationDomainDtos.Dtos;
using MediatR;
using System.Collections.Generic;

namespace ApplicationDomainServices.Queries.AccountQuery
{
    public class ReadAllAccountsQuery:IRequest<IEnumerable<AccountDto>>
    {

    }
}
