
using MediatR;
namespace ProjetoAPIEcommerce.Notifications
{
  public class ErroNotification : INotification
  {
    public string Erro { get; set; }
    public string PilhaErro { get; set; }
  }
}