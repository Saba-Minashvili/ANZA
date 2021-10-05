using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAuthentication.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        Task<Tuple<string, int>> AuthenticateAsync(UserAuthDto data);
        void SetAccountRepo(IRepository<Account> accountRepo);
    }
}
