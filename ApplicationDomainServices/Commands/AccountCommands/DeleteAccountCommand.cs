using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomainServices.Commands.AccountCommands
{
    public class DeleteAccountCommand:IRequest<bool>
    {
        public int AccountId { get; set; }
    }
}
