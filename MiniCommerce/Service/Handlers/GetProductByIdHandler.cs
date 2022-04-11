using AutoMapper;
using MediatR;
using MiniCommerce.Data.Database;
using MiniCommerce.Models;
using MiniCommerce.Service.Queries;
using Microsoft.EntityFrameworkCore;

namespace MiniCommerce.Service.Handlers
{
  public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, DetailProductDto>
  {

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductByIdHandler> _logger;

    public GetProductByIdHandler(AppDbContext context, IMapper mapper, ILogger<GetProductByIdHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<DetailProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        var product = _context.Products
            .Include(p => p.Category)
            .Where(p => p.Id == request.Id)
            .FirstOrDefault();
        if (product == null) { return null; }
        var response = _mapper.Map<DetailProductDto>(product);
        return response;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
        return null;
      }
    }
  }
}
