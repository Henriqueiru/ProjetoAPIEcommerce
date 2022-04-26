using AutoMapper;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;

namespace MiniCommerce.Mapper
{
  public class AddressProfile : Profile
  {
    public AddressProfile()
    {
      CreateMap<CreateAddressDto, Address>();
      CreateMap<Address, DetailAddressDto>();
    }
  }
}
