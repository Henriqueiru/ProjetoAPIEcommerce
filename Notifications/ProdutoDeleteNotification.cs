
using MediatR;
namespace ProjetoAPIEcommerce.Notifications
{
  public class ProdutoDeleteNotification : INotification
  {
    public int Id { get; set; }
    public bool IsConcluido { get; set; }
  }
}