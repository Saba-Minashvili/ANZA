using ApplicationDomainDtos.Dtos;
using MediatR;


namespace ApplicationDomainServices.Queries.AccountQueries
{
    public class ReadAccountByPropQuery : IRequest<AccountDto>
    {
        public int AccountId { get; set; }
    }
}
