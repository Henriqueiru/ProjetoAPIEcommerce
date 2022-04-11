using AutoMapper;
using MediatR;
using MiniCommerce.Data.Database;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Service.Queries;
using Microsoft.EntityFrameworkCore;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Handlers
{
  public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<DetailProductDto>>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductsHandler> _logger;

    public GetProductsHandler(AppDbContext context, IMapper mapper, ILogger<GetProductsHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<List<DetailProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
      try
      {
        var products = await _context.Products
            .Include(p => p.Category)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<DetailProductDto>>(products);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
        return new List<DetailProductDto>();
      }
    }
  }
}
