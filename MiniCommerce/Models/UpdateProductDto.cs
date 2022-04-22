using System;
using System.ComponentModel.DataAnnotations;

namespace MiniCommerce.Models
{
  public class UpdateProductDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    // Relationship
    [Required]
    public int CategoryId { get; set; }
  }
}