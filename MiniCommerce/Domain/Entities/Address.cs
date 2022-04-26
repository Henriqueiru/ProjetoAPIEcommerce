using System;

namespace MiniCommerce.Domain.Entities
{
  public class Address : BaseEntity
  {
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Zipcode { get; set; }
    List<Custumer> Custumers { get; set; }

  }
}