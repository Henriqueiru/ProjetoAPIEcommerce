using MediatR;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Queries
{
  public record GetCategoriesQuery : IRequest<List<DetailCategoryDto>>;
}
