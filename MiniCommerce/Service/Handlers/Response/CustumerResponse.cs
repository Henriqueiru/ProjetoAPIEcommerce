using System;
using MiniCommerce.Service.Common;

namespace MiniCommerce.Service.Handlers.Response
{
  public class CustumerResponse : BaseResponse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }

    //Relationship
    public string AdressId { get; set; }
  }
}