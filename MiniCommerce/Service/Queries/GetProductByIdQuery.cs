using MediatR;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Queries
{
  public record GetProductByIdQuery(int Id) : IRequest<DetailProductDto>;
}
