using MediatR;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Commands
{
  public record CreateAddressCommand(CreateAddressDto CreateAddressDto) : IRequest<DetailAddressDto>;
}
