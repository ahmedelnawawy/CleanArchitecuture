using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Lookps.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LookUpsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get Supplier List 
        [HttpGet("GetAllQuantityPerUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllQuantityPerUnit([FromQuery] QuantityPerUnitListQuery request = null)
        {
            if (request == null)
            {
                request = new QuantityPerUnitListQuery();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
