using System;

namespace ProjetoAPIEcommerce.Domain
{
  public class Custumer
  {
    public int Custumer_Id { get; set; }
    public string NameCustumer { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public Address Address { get; }
  }
}