using System;
using MediatR;

namespace ProjetoAPIEcommerce.Application
{
  public class ProductCreateCommand : IRequest<string>
  {
    public string Name { get; private set; }
    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public string Category { get; private set; }
  }
}