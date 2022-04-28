using Microsoft.EntityFrameworkCore;
using MiniCommerce.Domain.Entities;

namespace MiniCommerce.Data.Database
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
      Products = this.Set<Product>();
      Categories = this.Set<Category>();
      Custumers = this.Set<Custumer>();
      Addresses = this.Set<Address>();
    }

    public DbSet<Product> Products { get; private set; }
    public DbSet<Category> Categories { get; private set; }

    public DbSet<Custumer> Custumers { get; private set; }
    public DbSet<Address> Addresses { get; private set; }

    public override int SaveChanges()
    {
      SetProperties();
      return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

      SetProperties();
      return base.SaveChangesAsync(cancellationToken);
    }

    private void SetProperties()
    {
      foreach (var entity in ChangeTracker.Entries().Where(p => p.State == EntityState.Added))
      {
        var created = entity.Entity as BaseEntity;

      }

      foreach (var entity in ChangeTracker.Entries().Where(p => p.State == EntityState.Modified))
      {
        var updated = entity.Entity as BaseEntity;

      }
    }
  }
}
