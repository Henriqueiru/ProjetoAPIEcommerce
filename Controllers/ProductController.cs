using ProjetoAPIEcommerce.Domain;
using ProjetoAPIEcommerce.Application;
using ProjetoAPIEcommerce.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductController : ControllerBase
  {
    private IMediator Mediator { get; }

    public ProductController(IMediator mediator)
    {
      Mediator = mediator;
    }

    public async Task<ActionResult<ProductCommand>> DefineProduct([FromBody] ProductRequest request, CancellationToken cancellationToken)
    {
      var response = await Mediator.Send(request, cancellationToken);

      return Ok(response);
    }

  }
}