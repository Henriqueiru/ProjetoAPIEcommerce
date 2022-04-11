using MediatR;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Commands
{
  public record CreateCategoryCommand(CreateCategoryDto CreateCateogryDto) : IRequest<DetailCategoryDto>;
}
