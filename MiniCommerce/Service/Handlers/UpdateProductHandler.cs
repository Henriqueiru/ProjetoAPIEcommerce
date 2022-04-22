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
  public class UpdateProductHandler : IRequestHandler<UpdateProductByIdCommand, ProductResponse>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateProductHandler> _logger;

    public UpdateProductHandler(AppDbContext context, IMapper mapper, ILogger<UpdateProductHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<ProductResponse> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
    {
      var response = new ProductResponse();

      try
      {
        var checkExist = _context.Products
            .Where(p => p.Id == request.Id)
            .FirstOrDefault();
        if (checkExist == null) { throw new Exception("This id doesn't exists"); }

        _mapper.Map(request.UpdateProductDto, checkExist);

        _context.Products.Update(checkExist);
        if (await _context.SaveChangesAsync() > 0)
        {
          var result = _context.Products
                      .Where(p => p.Id == request.Id)
                      .FirstOrDefault();

          response = _mapper.Map<ProductResponse>(result);
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

    private async Task<ProductResponse> ReturnSuccess(ProductResponse response, string message)
    {
      response.Message = $"{message}";
      response.StatusCode = (int)HttpStatusCode.OK;

      return await Task.FromResult(response);
    }
  }
}
