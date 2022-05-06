using System;

namespace MiniCommerce.Repositories
{
  public interface IRepository<T>
  {
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);

    List<T> FindAll();
  }
}