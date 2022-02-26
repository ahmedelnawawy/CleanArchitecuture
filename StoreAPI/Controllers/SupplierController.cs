using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Suppliers.Commands;
using Store.Application.Suppliers.Queries;
using Store.Application.Suppliers.Responses;
using System;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get Supplier List 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] SupplierListQuery request = null)
        {
            if (request == null)
            {
                request = new SupplierListQuery();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // Get Supplier By Id 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new SupplierGetByIdQuery
            {
                Id = id
            });

            return Ok(result);
        }

        //// Get Supplier By Id 
        [HttpGet("GetLargestSupplierToStore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLargestSupplierToStore([FromQuery] GetLargestSupplierToStoreQuery request = null)
        {
            if (request == null)
            {
                request = new GetLargestSupplierToStoreQuery();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        //Create Supplier
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SupplierResponse>> Post([FromBody] SupplierAddCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Update Supplier
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] SupplierUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Delete Supplier
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new SupplierDeleteCommand()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
