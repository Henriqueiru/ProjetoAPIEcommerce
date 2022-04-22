using MiniCommerce.Service.Common;

namespace MiniCommerce.Service.Handlers.Response
{
  public class ProductResponse : BaseResponse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }
  }
}