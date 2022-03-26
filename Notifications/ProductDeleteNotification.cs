
using MediatR;

namespace ProjetoAPIEcommerce.Notifications
{
  public class ProductDeleteNotification : INotification
  {
    public int Id { get; set; }
    public bool IsConcluded { get; set; }
  }
}