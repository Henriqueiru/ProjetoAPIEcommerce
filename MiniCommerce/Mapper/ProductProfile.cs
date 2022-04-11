using AutoMapper;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;

namespace MiniCommerce.Mapper
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
      CreateMap<Product, DetailProductDto>();
      CreateMap<CreateProductDto, Product>();
    }
  }
}
