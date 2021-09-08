using Interview.Web.Dto.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Sparcpoint.Domain.Dto;

namespace Interview.Web.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{productId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProduct(int productId)
        {
            // Gaurd Conditions
            if (productId <=0)
            {
                return BadRequest("The Product Id should be positive.");
            }
            return new OkObjectResult(new GetProductResponseDto(123, 
                    "Mechanical Keyboard", 
                    "This is mechanical Keyboard",
                    new List<string>() { "ABCDEF123" },
                    null,
                    "#FFFFFFF",
                    105,
                    30, 
                    1000));
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<AddProductResponseDto>> AddProduct([FromBody] AddProductCommand addProductCommand)
        {

            // The AddProduct is implemented using the DDD and the Command Pattern from CQRS
            // Controller -> Command Handler -> Infrastructure -> SQL
            // 

            if (addProductCommand == null)
            {
                return BadRequest("The Add Product is not valid. Please check the Request.");
            }
            var newProduct = await _mediator.Send(addProductCommand);
            return CreatedAtAction(nameof(GetProduct), new { productId = newProduct.ProductId }, newProduct);
        }
    }
}
