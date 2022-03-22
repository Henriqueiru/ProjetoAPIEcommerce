
using MediatR;
namespace ProjetoAPIEcommerce.Notifications
{
  public class ProdutoCreateNotification : INotification
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Category_id { get; set; }
  }
}