using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoVenda { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        


    }
}