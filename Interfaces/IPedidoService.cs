using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Dtos;

namespace ECommerceAPI.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDTO>> ListarPedidosAsync();
        Task<PedidoDTO> CriarPedidoAsync(PedidoDTO pedidoDTO);
        Task<PedidoDTO> BuscarPedidoByIdAsync(int id);
        Task<bool> UpdatePedidoAsync(int id, PedidoDTO pedidoUpdateDTO);
        Task<bool> DeletePedidoAsync(int id);
    }
}