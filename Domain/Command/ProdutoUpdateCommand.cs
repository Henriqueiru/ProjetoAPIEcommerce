
using MediatR;
namespace ProjetoAPIEcommerce.Domain.Command
{
  // Essa classe é desnecessária, uma evz que tu ja tem a entidade Product que tu pode reaproveitar
  public class ProdutoUpdateCommand : IRequest<string>
  {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Category_id { get; set; }
  }
}
