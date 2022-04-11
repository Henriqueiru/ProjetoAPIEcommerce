using MediatR;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Queries
{
  public record GetProductsQuery : IRequest<List<DetailProductDto>>;
}
