using ProjetoAPIEcommerce.Domain;
using ProjetoAPIEcommerce.Infraestructure.Repository;
using ProjetoAPIEcommerce.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Application.Handler
{
  public class ProductCreateCommandHandler
  {
    private readonly IRepository<Product> _repository;

    public ProductCreateCommandHandler(IRepository<Product> repository)
    {
      this._repository = repository;
    }
    public async Task<string> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
      var product = new Product { Name = request.Name, Price = request.Price, Description = request.Description, Category_id = request.Category_id };

      try
      {
        await _repository.Add(product);
        return await Task.FromResult("Produto criado com sucesso");
      }
      catch (Exception ex)
      {

        return await Task.FromResult("Ocorreu um erro no momento da criação");
      }
    }
  }