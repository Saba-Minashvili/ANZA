using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomainServices.Commands.AccountCommands
{
    public class UpdateAccountCommand:IRequest<bool>
    {
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
    }
}
