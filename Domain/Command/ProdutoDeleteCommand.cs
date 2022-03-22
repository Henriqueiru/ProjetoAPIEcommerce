
using MediatR;
namespace ProjetoAPIEcommerce.Domain.Command
{
  public class ProdutoDeleteCommand : IRequest<string>
  {
    public int Id { get; set; }
  }
}