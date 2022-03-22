using ProjetoAPIEcommerce.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Domain.EventsHandlers
{
  public class LogEventHandler : INotificationHandler<ProdutoCreateNotification>, INotificationHandler<ProdutoUpdateNotification>, INotificationHandler<ProdutoDeleteNotification>, INotificationHandler<ErroNotification>
  {
    public Task Handle(ProdutoCreateNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
      {
        Console.WriteLine($"CRIACAO:'{notification.Id}" + $"- {notification.Name} - {notification.Price} - {notification.Description} - {notification.Category_id}'");
      });
    }
    public Task Handle(ProdutoUpdateNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
    {
      Console.WriteLine($"ALTERACAO:'{notification.Id}" + $"- {notification.Name} - {notification.Price} - {notification.Description} - {notification.Category_id} - {notification.IsConcluido}'");
    });
    }
    public Task Handle(ProdutoDeleteNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
    {
      Console.WriteLine($"EXCLUSAO:'{notification.Id}" + $"- {notification.IsConcluido}'");
    });
    }
    public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
    {
      Console.WriteLine($"ERRO:'{notification.Erro}\n {notification.PilhaErro}'");
    });
    }
  }
}