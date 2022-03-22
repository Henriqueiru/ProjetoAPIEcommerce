
using MediatR;
namespace ProjetoAPIEcommerce.Notifications
{
  public class ProdutoUpdateNotification : INotification
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Category_id { get; set; }
    public bool IsConcluido { get; set; }
  }
}