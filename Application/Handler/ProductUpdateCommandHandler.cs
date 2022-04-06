using ProjetoAPIEcommerce.Domain;
using ProjetoAPIEcommerce.Application;
using ProjetoAPIEcommerce.Infraestructure.Repository;
using ProjetoAPIEcommerce.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Application.Handler
{
  public class ProductUpdateCommandHandler
  {
    private readonly IMediator _mediator;
    private readonly IRepository<Product> _repository;
    public ProductUpdateCommandHandler(IMediator mediator, IRepository<Product> repository)
    {
      this._mediator = mediator;
      this._repository = repository;
    }
    public async Task<string> Handle(ProductUpdateCommand request,
        CancellationToken cancellationToken)
    {
      var product = new Product
      {
        Id = request.Id,
        Name = request.Name,
        Description = request.Description,
        Price = request.Price,
        Category = request.Category
      };
      try
      {
        await _repository.Edit(product);
        await _mediator.Publish(new ProductUpdateNotification
        { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price, Category = product.Category });
        return await Task.FromResult("Produto alterado com sucesso");
      }
      catch (Exception ex)
      {
        await _mediator.Publish(new ProductUpdateNotification
        {
          Id = product.Id,
          Name = product.Name,
          Description = request.Description,
          Price = request.Price,
          Category = request.Category
        });

        await _mediator.Publish(new ErrorNotification
        {
          Error = ex.Message,
          BatteryError = ex.StackTrace
        });
        return await Task.FromResult("Ocorreu um erro no momento da alteração");
      }
    }
  }
}