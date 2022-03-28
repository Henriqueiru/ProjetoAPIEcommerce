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
  public class ProductDeleteCommandHandler
  {
    private readonly IMediator _mediator;
    private readonly IRepository<Product> _repository;
    public ProductDeleteCommandHandler(IMediator mediator, IRepository<Product> repository)
    {
      this._mediator = mediator;
      this._repository = repository;
    }
    public async Task<string> Handle(ProductDeleteCommand request,
        CancellationToken cancellationToken)
    {
      try
      {
        await _repository.Delete(request.Id);
        await _mediator.Publish(new ProductDeleteNotification
        { Id = request.Id, IsConcluded = true });
        return await Task.FromResult("Produto excluido com sucesso");
      }
      catch (Exception ex)
      {
        await _mediator.Publish(new ProductDeleteNotification
        {
          Id = request.Id,
          IsConcluded = false
        });
        await _mediator.Publish(new ErrorNotification
        {
          Error = ex.Message,
          BatteryError = ex.StackTrace
        });
        return await Task.FromResult("Ocorreu um erro no momento da exclusão");
      }
    }
  }
}