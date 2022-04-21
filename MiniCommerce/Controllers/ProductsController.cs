using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using MiniCommerce.Service.Queries;

namespace MiniCommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
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
    public async Task<ActionResult<DetailProductDto>> CreateProduct(CreateProductDto productDto)
    {
      var result = await _mediator.Send(new CreateProductCommand(productDto));
      if (result == null) { return BadRequest(); }
      return Ok(result);
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



  }
}
