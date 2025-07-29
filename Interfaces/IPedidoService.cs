using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Dtos;

namespace ECommerceAPI.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoCreateDTO>> ListarPedidosAsync();
        Task<PedidoCreateDTO> CriarPedidoAsync(PedidoCreateDTO pedidoDTO);
        Task<PedidoCreateDTO> BuscarPedidoByIdAsync(int id);
        Task<bool> UpdatePedidoAsync(int id, PedidoCreateDTO pedidoUpdateDTO);
        Task<bool> DeletePedidoAsync(int id);
    }
}