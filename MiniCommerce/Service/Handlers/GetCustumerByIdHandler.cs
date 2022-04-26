using AutoMapper;
using MediatR;
using MiniCommerce.Data.Database;
using MiniCommerce.Models;
using MiniCommerce.Service.Queries;
using Microsoft.EntityFrameworkCore;

namespace MiniCommerce.Service.Handlers
{
  public class GetCustumerByIdHandler : IRequestHandler<GetCustumerByIdQuery, DetailCustumerDto>
  {

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCustumerByIdHandler> _logger;

    public GetCustumerByIdHandler(AppDbContext context, IMapper mapper, ILogger<GetCustumerByIdHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<DetailCustumerDto> Handle(GetCustumerByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        var custumer = _context.Custumers
            .Include(p => p.Address)
            .Where(p => p.Id == request.Id)
            .FirstOrDefault();
        if (custumer == null) { return null; }
        var response = _mapper.Map<DetailCustumerDto>(custumer);
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
