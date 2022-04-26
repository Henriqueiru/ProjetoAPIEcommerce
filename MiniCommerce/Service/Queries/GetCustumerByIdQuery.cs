using MediatR;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Queries
{
  public record GetCustumerByIdQuery(int Id) : IRequest<DetailCustumerDto>;
}
