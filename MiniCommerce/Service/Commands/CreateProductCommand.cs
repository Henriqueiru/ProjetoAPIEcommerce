using MediatR;
using MiniCommerce.Models;
using MiniCommerce.Service.Handlers.Response;

namespace MiniCommerce.Service.Commands
{
  public record CreateProductCommand(CreateProductDto CreateProductDto) : IRequest<ProductResponse>;

}
