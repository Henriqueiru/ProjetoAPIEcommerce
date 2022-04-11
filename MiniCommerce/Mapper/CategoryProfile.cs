using AutoMapper;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;

namespace MiniCommerce.Mapper
{
  public class CategoryProfile : Profile
  {
    public CategoryProfile()
    {
      CreateMap<CreateCategoryDto, Category>();
      CreateMap<Category, DetailCategoryDto>();
    }
  }
}
