using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Dtos
{
    public class ProdutoCreateDTO
    {
        public string Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
    
    }
}