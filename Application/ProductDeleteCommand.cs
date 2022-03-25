using System;
using MediatR;

namespace ProjetoAPIEcommerce.Application
{
  public class ProductDeleteCommand : IRequest<string>

  {
    public int Id { get; set; }
  }
}