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
    private readonly IMediator _mediator;
    private readonly IRepository<Product> _repository;

    public ProductCreateCommandHandler(IMediator mediator, IRepository<Product> repository)
    {
      this._mediator = mediator;
      this._repository = repository;
    }
    public async Task<string> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
      var product = new Product { Name = request.Name, Price = request.Price, Description = request.Description, Category_id = request.Category_id };

      try
      {
        await _repository.Add(product);
        await _mediator.Publish(new ProductCreateNotification { Id = product.Id, Name = product.Name, Price = product.Price, Description = product.Description, Category_id = product.Category_id });
        return await Task.FromResult("Produto criado com sucesso");
      }
      catch (Exception ex)
      {
        await _mediator.Publish(new ProductCreateNotification { Id = product.Id, Name = product.Name, Price = product.Price, Description = product.Description, Category_id = product.Category_id });
        await _mediator.Publish(new ErrorNotification { Error = ex.Message, BatteryError = ex.StackTrace });
        return await Task.FromResult("Ocorreu um erro no momento da criação");
      }
    }
  }