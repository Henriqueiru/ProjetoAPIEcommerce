using System;

namespace ProjetoAPIEcommerce.Domain
{
  public class Address
  {
    public Guid AdressId { get; set; }
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public char Zipcode { get; set; }
  }
}