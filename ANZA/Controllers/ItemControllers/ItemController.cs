using ApplicationDomainServices.Commands.ProductCommands;
using ApplicationDomainServices.Queries.ItemQueries;
using ApplicationDomainServices.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ANZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator = default;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<itemController>
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var command = new ReadAllItemQuery() { };
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
                var command = new ReadItemByIdQuery() { ItemId = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        [HttpGet("searchBy")]
        public async Task<IActionResult> Get(string itemName, double itemPrice, string itemType)
        {
            try
            {
                var command = new ReadItemsByPropQuery() { ItemName = itemName, ItemPrice = itemPrice, ItemType = itemType };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        // POST: api/<itemController>

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] AddItemCommand comm)
        {
            if (comm == null) { return BadRequest(); }
            try
            {
                var result = await _mediator.Send(comm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        // PUT: api/<itemController>
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] UpdateItemCommand comm)
        {
            if (comm == null) { return BadRequest(); }
            try
            {
                var command = new UpdateItemCommand() { Item = comm.Item, ItemId = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error occured", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        // DELETE: api/<itemController>
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id, DeleteItemCommand comm)
        {
            if (comm == null) { return BadRequest(); }
            try
            {
                var command = new DeleteItemCommand() { ItemId = id };
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
