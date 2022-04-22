using System;
using MediatR;
using MiniCommerce.Models;
using MiniCommerce.Service.Handlers.Response;

namespace MiniCommerce.Service.Commands
{
  public record DeleteProductByIdCommand(int Id) : IRequest<bool>;

}