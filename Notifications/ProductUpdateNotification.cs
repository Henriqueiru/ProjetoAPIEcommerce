
using MediatR;

namespace ProjetoAPIEcommerce.Notifications
{
  public class ProductUpdateNotification : INotification
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsConcluded { get; set; }
  }
}