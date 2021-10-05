using ApplicationDomainServices.Commands.AccountCommands;
using ApplicationDomainServices.Queries.AccountQueries;
using ApplicationDomainServices.Queries.AccountQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ANZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator = default;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<Accountcontroller>
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var command = new ReadAllAccountsQuery() { };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var command = new ReadAccountByPropQuery() { AccountId = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        // POST: api/<Accountcontroller>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateAccountCommand command)
        {
            if (command == null) { return BadRequest(); }

            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        // PUT: api/<Accountcontroller>
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] UpdateAccountCommand account)
        {
            if (account == null) { BadRequest(StatusCodes.Status204NoContent); }

            try
            {
                var command = new UpdateAccountCommand() { AccountId = id, Account = account.Account };
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        // DELETE: api/<AccountController>
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id, DeleteAccountCommand account)
        {
            if (account == null) { return BadRequest(); }

            try
            {
                var command = new DeleteAccountCommand() { AccountId = id };
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }
    }
}
