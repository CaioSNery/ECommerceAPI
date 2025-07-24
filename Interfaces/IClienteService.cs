using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Dtos;

namespace ECommerceAPI.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteReadDTO>> ListarClientesAsync();
        Task<ClienteReadDTO> BuscarClienteByIdAsync(int id);
        Task<ClienteReadDTO> CriarClienteAsync(ClienteCreateDTO clienteCreateDTO);
        Task<ClienteReadDTO> UpdateClienteAsync(int id, ClienteCreateDTO clienteUpdateDTO);
        Task<bool> DeleteClienteAsync(int id);
    }
}