using MiniCommerce.Domain.Entities;

namespace MiniCommerce.Models
{
  public class DetailProductDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    // Relationship
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  }
}
