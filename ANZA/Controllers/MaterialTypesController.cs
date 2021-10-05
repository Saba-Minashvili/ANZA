using ApplicationDomainServices.Commands;
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
    public class MaterialTypesController : Controller
    {
        private readonly IMediator _mediator = default;

        public MaterialTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMaterialTypesCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured.", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        [HttpGet("{itemTypeId}")]
        public async Task<IActionResult> Get(int itemTypeId)
        {
            try
            {
                var command = new ReadItemMaterialTypesQuery() { ItemTypeId = itemTypeId };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("No item was found", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }
    }
}
