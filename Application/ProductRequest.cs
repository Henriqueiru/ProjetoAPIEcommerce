using System;
using ProjetoAPIEcommerce.Domain;
using MediatR;

namespace ProjetoAPIEcommerce.Application
{
  public class ProductRequest : IRequest<ProductResponse>
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
  }
}