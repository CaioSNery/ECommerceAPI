using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Dtos
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }

        public int Quantidade { get; set; }

        public int CarrinhoId { get; set; }

        public int ClienteId { get; set; }

        public int ProdutoId { get; set; }

        public decimal ValorTotal { get; set; }
    }
}