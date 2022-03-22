using ProjetoAPIEcommerce.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace ProjetoAPIEcommerce.Application.EventsHandler
{
  public class LogEventHandler : INotificationHandler<ProductCreateNotification>, INotificationHandler<ProductUpdateNotification>, INotificationHandler<ProductDeleteNotification>, INotificationHandler<ErrorNotification>
  {
    public Task Handle(ProductCreateNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
      {
        Console.WriteLine($"CRIACAO:'{notification.Id}" + $"- {notification.Name} - {notification.Price} - {notification.Description} - {notification.Category}'");
      });
    }
    public Task Handle(ProductUpdateNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
    {
      Console.WriteLine($"ALTERACAO:'{notification.Id}" + $"- {notification.Name} - {notification.Price} - {notification.Description} - {notification.Category} - {notification.IsConcluded}'");
    });
    }
    public Task Handle(ProductDeleteNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
    {
      Console.WriteLine($"EXCLUSAO:'{notification.Id}" + $"- {notification.IsConcluded}'");
    });
    }
    public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
    {
      Console.WriteLine($"ERRO:'{notification.Error}\n {notification.BatteryError}'");
    });
    }
  }
}