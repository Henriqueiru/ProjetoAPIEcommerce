using ProjetoAPIEcommerce.Domain.Command;
using ProjetoAPIEcommerce.Domain.Entity;
using ProjetoAPIEcommerce.Notifications;
using ProjetoAPIEcommerce.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Domain.Handler
{
  public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, string>
  {
    private readonly IMediator _mediator;
    private readonly IRepository<Produto> _repository;

    public ProdutoUpdateCommandHandler(IMediator mediator, IRepository<Produto> repository)
    {
      this._mediator = mediator;
      this._repository = repository;
    }
    public async Task<string> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
    {
      var produto = new Produto { Name = request.Name, Price = request.Price, Description = request.Description, Category_id = request.Category_id };

      try
      {
        await _repository.Edit(produto);
        await _mediator.Publish(new ProdutoUpdateNotification { Id = produto.Id, Name = produto.Name, Price = produto.Price, Description = produto.Description, Category_id = produto.Category_id });
        return await Task.FromResult("Produto alterado com sucesso");
      }
      catch (Exception ex)
      {
        await _mediator.Publish(new ProdutoUpdateNotification { Id = produto.Id, Name = produto.Name, Price = produto.Price, Description = produto.Description, Category_id = produto.Category_id });
        await _mediator.Publish(new ErroNotification { Erro = ex.Message, PilhaErro = ex.StackTrace });
        return await Task.FromResult("Ocorreu um erro no momento da alteração");
      }
    }
  }
}