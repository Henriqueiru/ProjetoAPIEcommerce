using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using MiniCommerce.Service.Handlers.response;
using MiniCommerce.Service.Queries;

namespace MiniCommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Consumes(MediaTypeNames.Application.Json)]
  [Produces(MediaTypeNames.Application.Json)]
  public class ProductsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
      _mediator = mediator;
      _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<ProductResponse>> CreateProduct(CreateProductDto productDto)
    {

      var result = await _mediator.Send(new CreateProductCommand(productDto));
      if (result == null) { return BadRequest(); }
      return CreatedAtAction("GetProductById", new { id = result.ProductId }, result);

    }

    [HttpGet]
    public async Task<ActionResult<List<DetailProductDto>>> GetProducts()
    {
      var result = await _mediator.Send(new GetProductsQuery());
      return Ok(result);
    }

    [HttpGet("id")]
    public async Task<ActionResult<DetailProductDto>> GetProductById(int id)
    {
      var product = await _mediator.Send(new GetProductByIdQuery(id));
      if (product == null) { return NotFound(); }
      return Ok(product);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteProduct(int id)
    {
      var command = new DeleteProductByIdCommand(id);
      var result = await _mediator.Send(command);
      if (!result) { return NotFound(); }
      return Ok();
    }


  }
}
