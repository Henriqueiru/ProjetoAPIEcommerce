using MediatR;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Queries
{
  public record GetCustumersQuery : IRequest<List<DetailCustumerDto>>;
}
