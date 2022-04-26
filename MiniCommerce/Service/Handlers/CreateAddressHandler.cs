using MediatR;
using MiniCommerce.Data.Database;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MiniCommerce.Domain.Entities;

namespace MiniCommerce.Service.Handlers
{
  public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, DetailAddressDto>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateAddressHandler> _logger;

    public CreateAddressHandler(AppDbContext context, IMapper mapper, ILogger<CreateAddressHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }


    public async Task<DetailAddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
      try
      {
        var address = _mapper.Map<Address>(request.CreateAddressDto);
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return _mapper.Map<DetailAddressDto>(address);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
        return null;
      }
    }
  }
}
