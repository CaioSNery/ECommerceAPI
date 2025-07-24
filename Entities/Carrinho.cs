using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int QuantidadeProduto { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

    

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        
    }
}