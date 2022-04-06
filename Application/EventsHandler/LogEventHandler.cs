using ProjetoAPIEcommerce.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Application.EventsHandler
{
  public class LogEventHandler : INotificationHandler<ProductCreateNotification>,
  INotificationHandler<ProductUpdateNotification>,
  INotificationHandler<ProductDeleteNotification>,
  INotificationHandler<ErrorNotification>
  {
    public Task Handle(ProductCreateNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
      {
        Console.WriteLine($"CREATED: '{notification.Id} " +
                  $"- {notification.Name} - {notification.Description}  - {notification.Price} - {notification.Category}'");
      });
    }
    public Task Handle(ProductUpdateNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
      {
        Console.WriteLine($"UPDATED: '{notification.Id} - {notification.Name} " +
                  $"- {notification.Description}  - {notification.Price} - {notification.Category} - {notification.IsConcluded}'");
      });
    }
    public Task Handle(ProductDeleteNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
      {
        Console.WriteLine($"DELETED: '{notification.Id} " +
                  $"- {notification.IsConcluded}'");
      });
    }
    public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
      {
        Console.WriteLine($"ERROR: '{notification.Error} \n {notification.BatteryError}'");
      });
    }
  }
}