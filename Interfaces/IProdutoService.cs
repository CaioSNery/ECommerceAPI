using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Dtos;

namespace ECommerceAPI.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoReadDTO>> ListarProdutosAsync();
        
        Task<ProdutoReadDTO> BuscarProdutoByIdAsync(int id);

        Task<ProdutoReadDTO> CriarProdutoAsync(ProdutoCreateDTO dto);

        Task<bool> AtualizarProdutoAsync(int id, ProdutoCreateDTO dto);

        Task<bool> DeletarProdutoAsync(int id);
        
    }
}