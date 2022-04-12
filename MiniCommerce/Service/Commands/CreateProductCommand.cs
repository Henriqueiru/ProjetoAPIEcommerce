using MediatR;
using MiniCommerce.Models;
using MiniCommerce.Service.Handlers.response;

namespace MiniCommerce.Service.Commands
{
  public record CreateProductCommand(CreateProductDto CreateProductDto) : IRequest<ProductResponse>;

}
