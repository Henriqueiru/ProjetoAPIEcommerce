using System;
using MediatR;

namespace ProjetoAPIEcommerce.Domain
{
  public class Product : IRequest<string>
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; }
  }
}