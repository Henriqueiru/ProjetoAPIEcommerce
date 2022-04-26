using AutoMapper;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using MiniCommerce.Service.Handlers.Response;

namespace MiniCommerce.Mapper
{
  public class CustumerProfile : Profile
  {
    public CustumerProfile()
    {
      CreateMap<Custumer, DetailCustumerDto>().ReverseMap();
      CreateMap<CreateCustumerDto, Custumer>().ReverseMap();
      CreateMap<UpdateCustumerDto, Custumer>().ReverseMap();
      CreateMap<Custumer, CustumerResponse>().ReverseMap();
      CreateMap<Custumer, UpdateCustumerByIdCommand>().ReverseMap();
    }
  }
}
