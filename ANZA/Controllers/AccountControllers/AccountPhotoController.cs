using ApplicationDomainServices.Commands;
using ApplicationDomainServices.Queries.PhotoQueiries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ANZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountPhotoController : ControllerBase
    {
        private readonly IMediator _mediator = default;

        public AccountPhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(int accountId)
        {
            try
            {
                var command = new ReadAccountPhotoQuery() { AccountId = accountId };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("No photo was founded.", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountPhotoCommand command)
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
    }
}
