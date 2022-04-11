using MediatR;
using MiniCommerce.Data.Database;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MiniCommerce.Domain.Entities;

namespace MiniCommerce.Service.Handlers
{
  public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, DetailCategoryDto>
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryHandler> _logger;

    public CreateCategoryHandler(AppDbContext context, IMapper mapper, ILogger<CreateCategoryHandler> logger)
    {
      _context = context;
      _mapper = mapper;
      _logger = logger;
    }


    public async Task<DetailCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
      try
      {
        var category = _mapper.Map<Category>(request.CreateCateogryDto);
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return _mapper.Map<DetailCategoryDto>(category);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
        return null;
      }
    }
  }
}
