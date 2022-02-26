
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Products.Commands;
using Store.Application.Products.Queries;
using Store.Application.Products.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region Get Section
        // Get Product List 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] ProductListQuery request = null)
        {
            if (request == null)
            {
                request = new ProductListQuery();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        
        // Get Product By Id 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Int64 id)
        {
            var result = await _mediator.Send(new ProductGetByIdQuery
            {
                Id = id
            });

            return Ok(result);
        }

        // Get Product By Filter
        [HttpPost("GetByFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByFilter(ProductSearchQuery request = null)
        {
            if (request == null)
            {
                request = new ProductSearchQuery();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // Get Product Need ReOrder
        [HttpGet("GetProductNeedReOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductNeedReOrder([FromQuery] GetProductNeedReOrderQuery request = null)
        {
            if (request == null)
            {
                request = new GetProductNeedReOrderQuery();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        #endregion

        //Create Product
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductResponse>> Post([FromBody] ProductAddCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Update Product
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] ProductUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Delete Product
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            var result = await _mediator.Send(new ProductDeleteCommand()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
