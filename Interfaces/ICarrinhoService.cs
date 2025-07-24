using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Dtos;

namespace ECommerceAPI.Interfaces
{
    public interface ICarrinhoService
    {
        Task<IEnumerable<CarrinhoDTO>> ListarCarrinhosAsync();

        Task<CarrinhoDTO> CriarCarrinhoAsync(CarrinhoDTO carrinhoDTO);
    }
}