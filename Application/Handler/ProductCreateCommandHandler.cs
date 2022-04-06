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
  public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, string>
  {
    private readonly IMediator _mediator;
    private readonly IRepository<Product> _repository;

    public ProductCreateCommandHandler(IMediator mediator, IRepository<Product> repository)
    {
      this._mediator = mediator;
      this._repository = repository;
    }
    public async Task<string> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
      var product = new Product { Name = request.Name, Description = request.Description, Price = request.Price, Category = request.Category };

      try
      {
        await _repository.Add(product);
        await _mediator.Publish(new ProductCreateNotification { Id = product.Id, Name = product.Name, Description = product.Description, Price = request.Price, Category = product.Category });
        return await Task.FromResult("Add Product sucessfull");
      }
      catch (Exception ex)
      {
        await _mediator.Publish(new ProductCreateNotification { Id = product.Id, Name = product.Name, Description = product.Description, Price = request.Price, Category = product.Category });
        await _mediator.Publish(new ErrorNotification { Error = ex.Message, BatteryError = ex.StackTrace });
        return await Task.FromResult("Ocorreu um erro no momento da criação");
      }
    }
  }
}