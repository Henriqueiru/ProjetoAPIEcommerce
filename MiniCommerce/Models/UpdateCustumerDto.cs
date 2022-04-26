using System;
using System.ComponentModel.DataAnnotations;

namespace MiniCommerce.Models
{
  public class UpdateCustumerDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Document { get; set; }

    //Relationship
    [Required]
    public string AdressId { get; set; }
  }
}