using ProjetoAPIEcommerce.Domain;
using ProjetoAPIEcommerce.Infraestructure.Repository;
using ProjetoAPIEcommerce.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Application.Handler
{
  public class ProductUpdateCommandHandler : IRequestHandler<Product>
  {
    private readonly IRepository<Product> _repository;

    public ProductUpdateCommandHandler(IRepository<Product> repository)
    {
      this._repository = repository;
    }
    public async Task<string> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
      var product = new Product { Name = request.Name, Price = request.Price, Description = request.Description, Category = request.Category };

      try
      {
        await _repository.Edit(product);

        return await Task.FromResult("Product changed sucessfull");
      }
      catch (Exception ex)
      {

        return await Task.FromResult("Error ocurred in Update");
      }
    }
  }