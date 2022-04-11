using AutoMapper;
using MediatR;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using Microsoft.EntityFrameworkCore;
using MiniCommerce.Data.Database;

namespace MiniCommerce.Service.Handlers
{
  public class CreateProductHandler : IRequestHandler<CreateProductCommand, DetailProductDto>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(AppDbContext context, IMapper mapper, ILogger<CreateProductHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<DetailProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
      try
      {
        var product = _mapper.Map<Product>(request.CreateProductDto);
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<DetailProductDto>(product);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
        return null;
      }
    }
  }
}
