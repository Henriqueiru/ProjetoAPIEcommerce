using System;

namespace MiniCommerce.Domain.Entities
{
  public class Custumer : BaseEntity
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }

    //Relationship
    public string AdressId { get; set; }
    public Address Address { get; set; }

  }
}