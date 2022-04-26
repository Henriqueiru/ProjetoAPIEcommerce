using System.ComponentModel.DataAnnotations;

namespace MiniCommerce.Models
{
  public class CreateAddressDto
  {
    [Required]
    public string Street { get; set; }
    [Required]
    public string Neighborhood { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Province { get; set; }
    [Required]
    public string Zipcode { get; set; }
  }
}
