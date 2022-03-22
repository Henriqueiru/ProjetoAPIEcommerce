
using MediatR;
namespace ProjetoAPIEcommerce.Notifications
{
  public class ErrorNotification : INotification
  {
    public string Error { get; set; }
    public string BatteryError { get; set; }
  }
}