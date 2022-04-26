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
  public class UpdateCustumerHandler : IRequestHandler<UpdateCustumerByIdCommand, CustumerResponse>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCustumerHandler> _logger;

    public UpdateCustumerHandler(AppDbContext context, IMapper mapper, ILogger<UpdateCustumerHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<CustumerResponse> Handle(UpdateCustumerByIdCommand request, CancellationToken cancellationToken)
    {
      var response = new CustumerResponse();

      try
      {
        var checkExist = _context.Custumers
            .Where(p => p.Id == request.Id)
            .FirstOrDefault();
        if (checkExist == null) { throw new Exception("This id doesn't exists"); }

        _mapper.Map(request.UpdateCustumerDto, checkExist);

        _context.Custumers.Update(checkExist);
        if (await _context.SaveChangesAsync() > 0)
        {
          var result = _context.Custumers
                      .Where(p => p.Id == request.Id)
                      .FirstOrDefault();

          response = _mapper.Map<CustumerResponse>(result);
          return await ReturnSuccess(response, "Success");

        }
        return null;

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
      response.StatusCode = (int)HttpStatusCode.OK;

      return await Task.FromResult(response);
    }
  }
}
