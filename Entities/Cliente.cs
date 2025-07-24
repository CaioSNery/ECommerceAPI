using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<Carrinho> Carrinhos { get; set; } = new List<Carrinho>();


    }
}