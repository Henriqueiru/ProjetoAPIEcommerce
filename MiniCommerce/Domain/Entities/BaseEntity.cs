using System.ComponentModel.DataAnnotations.Schema;

namespace MiniCommerce.Domain.Entities
{
  public abstract class BaseEntity
  {
    public int Id { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
  }
}
