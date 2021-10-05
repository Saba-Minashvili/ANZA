using ApplicationDomainServices.Commands.ProductCommands;
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
    public class ItemPhotoController : ControllerBase
    {
        private readonly IMediator _mediator = default;

        public ItemPhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> Get(int itemId)
        {
            try
            {
                var command = new ReadItemPhotoQuery() { ItemId = itemId };
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
        public async Task<IActionResult> Post([FromBody] ItemPictureCommand command)
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
