using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniCommerce.Data.Database;
using MiniCommerce.Service.Commands;

namespace MiniCommerce.Service.Handlers
{
  public class DeleteCustumerByIdHandler : IRequestHandler<DeleteCustumerByIdCommand, bool>
  {
    private readonly AppDbContext _context;
    private readonly ILogger<DeleteCustumerByIdHandler> _logger;

    public DeleteCustumerByIdHandler(AppDbContext context, ILogger<DeleteCustumerByIdHandler> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<bool> Handle(DeleteCustumerByIdCommand request, CancellationToken cancellationToken)
    {
      var custumer = await _context.Custumers.Where(p => p.Id == request.Id)
          .FirstOrDefaultAsync();
      if (custumer == null) { return false; }
      _context.Custumers.Remove(custumer);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}