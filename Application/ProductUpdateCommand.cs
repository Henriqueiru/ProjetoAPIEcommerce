using System;
using MediatR;

namespace ProjetoAPIEcommerce.Application
{
  public class ProductUpdateCommand : IRequest<string>
  {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string Category { get; private set; }
  }
}