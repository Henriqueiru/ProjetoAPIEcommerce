using System;
using ProjetoAPIEcommerce.Domain;
using MediatR;

namespace ProjetoAPIEcommerce.Application
{
  public class ProductResponse
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public DateTime Date { get; set; }
  }
}