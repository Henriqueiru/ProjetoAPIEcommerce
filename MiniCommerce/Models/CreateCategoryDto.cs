using System.ComponentModel.DataAnnotations;

namespace MiniCommerce.Models
{
  public class CreateCategoryDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
  }
}
