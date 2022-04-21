// using System;
// using AutoMapper;
// using MediatR;
// using MiniCommerce.Data.Database;
// using MiniCommerce.Models;
// using MiniCommerce.Service.Queries;
// using Microsoft.EntityFrameworkCore;

// namespace MiniCommerce.Service.Handlers
// {
//   public class RemoveProductHandler : IRequestHandler<GetProductByIdQuery, DetailProductDto>
//   {
//     private readonly AppDbContext _context;
//     private readonly IMapper _mapper;
//     private readonly ILogger<RemoveProductHandler> _logger;
//     public RemoveProductHandler(AppDbContext context, IMapper mapper, ILogger<RemoveProductHandler> logger)
//     {
//       _context = context;
//       _mapper = mapper;
//       _logger = logger;
//     }
//     public async Task<DetailProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
//     {
//       try
//       {
//         var product = _mapper.Map<Product>(request.CreateProductDto);
//         await _context.Products.Remove(product);
//         await _context.SaveChangesAsync();
//         return Ok();
//       }
//       catch (Exception ex)
//       {
//         _logger.LogError(ex.ToString());
//         return null;
//       }
//     }
//   }
// }