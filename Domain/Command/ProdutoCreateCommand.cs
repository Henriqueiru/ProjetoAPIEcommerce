using System;
using MediatR;
namespace ProjetoAPIEcommerce.Domain.Command
{
  public class ProdutoCreateCommand : IRequest<string>
  {
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; set; }
    public int Category_id { get; set; }
  }
}