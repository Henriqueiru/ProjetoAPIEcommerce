using AutoMapper;
using MediatR;
using MiniCommerce.Domain.Entities;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using Microsoft.EntityFrameworkCore;
using MiniCommerce.Data.Database;
using MiniCommerce.Service.Handlers.response;
using System.Net;
using MiniCommerce.Service.Common;

namespace MiniCommerce.Service.Handlers
{
  public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
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

    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
      var response = new ProductResponse();

      try
      {
        var product = _mapper.Map<Product>(request.CreateProductDto);
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return await ReturnSuccess(response, "Success");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());

        response.Message = $"{ex.Message}";
        response.StatusCode = (int) HttpStatusCode.BadRequest;

        return await Task.FromResult(response);
      }
    }

    private async Task<ProductResponse> ReturnSuccess(ProductResponse response, string message)
    {
      response.Message = $"{message}";
      response.StatusCode = (int) HttpStatusCode.Created;

      return await Task.FromResult(response);
    }
  }
}
