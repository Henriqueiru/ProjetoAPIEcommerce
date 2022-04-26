using System;
using MediatR;
using MiniCommerce.Models;
using MiniCommerce.Service.Handlers.Response;

namespace MiniCommerce.Service.Commands
{
  public record DeleteCustumerByIdCommand(int Id) : IRequest<bool>;

}