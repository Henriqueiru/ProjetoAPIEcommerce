using ProjetoAPIEcommerce.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIEcommerce.Infraestructure.Repository
{
  public class ProductRepository : IRepository<Product>
  {
    private Dictionary<int, Product> products = new Dictionary<int, Product>();

    public Dictionary<int, Product> GetProducts()
    {
      products.Add(1, new Product { Id = 1, Name = "Caneta", Price = 3.45m, Description = "This is a material", Category = "Material" });
      products.Add(2, new Product { Id = 2, Name = "Caderno", Price = 7.65m, Description = "This is a papper", Category = "Papel" });
      return products;
    }
    public ProductRepository()
    {
      products = GetProducts();
    }
    public async Task<IEnumerable<Product>> GetAll()
    {
      return await Task.Run(() => products.Values.ToList());
    }
    public async Task<Product> Get(int id)
    {
      return await Task.Run(() => products.GetValueOrDefault(id));
    }
    public async Task Add(Product product)
    {

      await Task.Run(() => products.Add(product.Id, product));
    }
    public async Task Edit(Product product)
    {
      await Task.Run(() =>
      {
        products.Remove(product.Id);
        products.Add(product.Id, product);
      });
    }
    public async Task Delete(int id)
    {
      await Task.Run(() => products.Remove(id));
    }
  }
}