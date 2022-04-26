using MediatR;
using MiniCommerce.Models;
using MiniCommerce.Service.Handlers.Response;

namespace MiniCommerce.Service.Commands
{
  public record UpdateCustumerByIdCommand(int Id, UpdateCustumerDto UpdateCustumerDto) : IRequest<CustumerResponse>;

}
