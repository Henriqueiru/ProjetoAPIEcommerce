using ProjetoAPIEcommerce.Domain;
using ProjetoAPIEcommerce.Application;
using ProjetoAPIEcommerce.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IRepository<Product> _repository;

    public ProductController(IMediator mediator, IRepository<Product> repository)
    {
      this._mediator = mediator;
      this._repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _repository.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return Ok(await _repository.Get(id));
    }


    [HttpPost]
    public async Task<IActionResult> Post(ProductCreateCommand command)
    {
      var response = await _mediator.Send(command);
      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(ProductUpdateCommand command)
    {
      var response = await _mediator.Send(command);
      return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var obj = new ProductDeleteCommand { Id = id };
      var result = await _mediator.Send(obj);
      return Ok(result);
    }


  }
}