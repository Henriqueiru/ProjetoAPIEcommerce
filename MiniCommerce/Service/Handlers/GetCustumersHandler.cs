using AutoMapper;
using MediatR;
using MiniCommerce.Data.Database;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Service.Queries;
using Microsoft.EntityFrameworkCore;
using MiniCommerce.Models;

namespace MiniCommerce.Service.Handlers
{
  public class GetCustumersHandler : IRequestHandler<GetCustumersQuery, List<DetailCustumerDto>>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCustumersHandler> _logger;

    public GetCustumersHandler(AppDbContext context, IMapper mapper, ILogger<GetCustumersHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<List<DetailCustumerDto>> Handle(GetCustumersQuery request, CancellationToken cancellationToken)
    {
      try
      {
        var custumers = await _context.Custumers
            .Include(p => p.Address)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<DetailCustumerDto>>(custumers);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
        return new List<DetailCustumerDto>();
      }
    }
  }
}
