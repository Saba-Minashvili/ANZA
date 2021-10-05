using ApplicationDomainServices.Queries.ItemQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ANZA.Controllers.ItemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypesController : Controller
    {

        private readonly IMediator _mediator = default;

        public ItemTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var command = new ReadItemTypesQuery();
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("No item was founded.", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }
    }
}
