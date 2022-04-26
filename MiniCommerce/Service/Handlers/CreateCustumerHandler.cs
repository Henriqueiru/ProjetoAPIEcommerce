using AutoMapper;
using MediatR;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using Microsoft.EntityFrameworkCore;
using MiniCommerce.Data.Database;
using MiniCommerce.Service.Handlers.Response;
using System.Net;
using MiniCommerce.Service.Common;

namespace MiniCommerce.Service.Handlers
{
  public class CreateCustumerHandler : IRequestHandler<CreateCustumerCommand, CustumerResponse>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCustumerHandler> _logger;

    public CreateCustumerHandler(AppDbContext context, IMapper mapper, ILogger<CreateCustumerHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<CustumerResponse> Handle(CreateCustumerCommand request, CancellationToken cancellationToken)
    {
      var response = new CustumerResponse();

      try
      {
        var custumer = _mapper.Map<Custumer>(request.CreateCustumerDto);
        await _context.Custumers.AddAsync(custumer);
        await _context.SaveChangesAsync();

        response = _mapper.Map<CustumerResponse>(custumer);
        return await ReturnSuccess(response, "Success");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());

        response.Message = $"{ex.Message}";
        response.StatusCode = (int)HttpStatusCode.BadRequest;

        return await Task.FromResult(response);
      }
    }

    private async Task<CustumerResponse> ReturnSuccess(CustumerResponse response, string message)
    {
      response.Message = $"{message}";
      response.StatusCode = (int)HttpStatusCode.Created;

      return await Task.FromResult(response);
    }
  }
}
