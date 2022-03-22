using ProjetoAPIEcommerce.Domain.Command;
using ProjetoAPIEcommerce.Domain.Entity;
using ProjetoAPIEcommerce.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // Nome da classe deve estar em inglês
  public class ProdutosController : ControllerBase
  {
    private readonly IMediator _mediator;
    // não precisa injetar o repository aqui, uma vez que isso vai ser feito no respectivo command e usa prop ao inves dessa declaração de variavel tipada
    private readonly IRepository<Produto> _repository;

    public ProdutosController(IMediator mediator, IRepository<Produto> repository)
    {
      
      this._mediator = mediator;
      this._repository = repository;
    }

    [HttpGet]
    // usar nomes mais declarativos para metodos
    public async Task<IActionResult> Get()
    {
      return Ok(await _repository.GetAll());
    }
    // seguindo o comentario anterior evitar a repetição de nomes de metodos, pois isso gera conflito
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return Ok(await _repository.Get(id));
    }


    [HttpPost]
    public async Task<IActionResult> Post(ProdutoCreateCommand command)
    {
      var response = await _mediator.Send(command);
      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(ProdutoUpdateCommand command)
    {
      var response = await _mediator.Send(command);
      return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var obj = new ProdutoDeleteCommand { Id = id };
      var result = await _mediator.Send(obj);
      return Ok(result);
    }


  }
}
