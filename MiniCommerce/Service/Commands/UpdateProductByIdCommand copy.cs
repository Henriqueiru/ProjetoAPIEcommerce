using MediatR;
using MiniCommerce.Models;
using MiniCommerce.Service.Handlers.Response;

namespace MiniCommerce.Service.Commands
{
  public record UpdateProductByIdCommand(int Id, UpdateProductDto UpdateProductDto) : IRequest<ProductResponse>;

}
