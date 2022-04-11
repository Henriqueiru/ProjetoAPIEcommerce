﻿namespace MiniCommerce.Domain.Entities
{
  public class Product : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }

    // Relationship
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  }
}
