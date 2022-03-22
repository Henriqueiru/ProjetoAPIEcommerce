using System;
using MediatR;
// aqui deixa uma linha em branco pra separar os usings do resto
namespace ProjetoAPIEcommerce.Domain.Command
{
  // Nome da classe deve ser em inglês
  // A pasta command não deve ficar dentro de Domain ela tem que icar em Application
  // pra simpliicar renomeia para Product, retira a implementação da inteface e deixa essa classe ora da pasta command e dentro da classe Domain 
  public class ProdutoCreateCommand : IRequest<string>
  {
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; set; }
    public int Category_id { get; set; }
  }
}
