using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Dtos
{
    public class ProdutoReadDTO
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string NomeCategoria { get; set; }
    }
}