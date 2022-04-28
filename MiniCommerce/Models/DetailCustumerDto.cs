using MiniCommerce.Domain.Entities;

namespace MiniCommerce.Models
{
  public class DetailCustumerDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }

    //Relationship
    public string AdressId { get; set; }
    public Address Address { get; set; }


  }
}
