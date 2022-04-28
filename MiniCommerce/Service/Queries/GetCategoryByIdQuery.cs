using MediatR;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Queries
{
  public record GetCategoryByIdQuery(int Id) : IRequest<DetailCategoryDto>;
}
