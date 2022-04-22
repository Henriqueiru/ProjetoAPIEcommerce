using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniCommerce.Data.Database;
using MiniCommerce.Service.Commands;

namespace MiniCommerce.Service.Handlers
{
  public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdCommand, bool>
  {
    private readonly AppDbContext _context;
    private readonly ILogger<DeleteProductByIdHandler> _logger;

    public DeleteProductByIdHandler(AppDbContext context, ILogger<DeleteProductByIdHandler> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
      var product = await _context.Products.Where(p => p.Id == request.Id)
          .FirstOrDefaultAsync();
      if (product == null) { return false; }
      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}