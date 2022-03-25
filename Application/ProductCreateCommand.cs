using System;
using MediatR;

namespace ProjetoAPIEcommerce.Application
{
  public class ProductCreateCommand : IRequest<string>
  {
    public string Name { get; private set; }
    public string Description { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; }
  }
}