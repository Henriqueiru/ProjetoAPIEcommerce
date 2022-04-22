using AutoMapper;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using MiniCommerce.Service.Handlers.Response;

namespace MiniCommerce.Mapper
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
      CreateMap<Product, DetailProductDto>().ReverseMap();
      CreateMap<CreateProductDto, Product>().ReverseMap();
      CreateMap<UpdateProductDto, Product>().ReverseMap();
      CreateMap<Product, ProductResponse>().ReverseMap();
      CreateMap<Product, UpdateProductByIdCommand>().ReverseMap();
    }
  }
}
