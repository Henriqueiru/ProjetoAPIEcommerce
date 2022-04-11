using MediatR;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Commands
{
  public record CreateProductCommand(CreateProductDto CreateProductDto) : IRequest<DetailProductDto>;

}
