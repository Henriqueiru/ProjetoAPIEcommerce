using ProjetoAPIEcommerce.Domain;
using System.Net;
using MediatR;

namespace ProjetoAPIEcommerce.Application
{
  public class ProductCommand : IRequestHandler<ProductRequest, ProductResponse>
  {
    public async Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
      var result = new ProductResponse();

      try
      {
        var newProduct = new Product
        {
          Id = 1,
          Name = "Wine",
          Description = "The best wine of my life",
          Price = 10,
          Category = 2
        };

        return await Task.FromResult(result);
      }
      catch (System.Exception)
      {

        throw;
      }
    }
  }
}