using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Dtos;

namespace ECommerceAPI.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> ListarCategoriasAsync();

        Task<CategoriaDTO> BuscarCategoriaByIdAsync(int id);
        
        Task<CategoriaDTO> CriarCategoriaAsync(CategoriaCreateDTO dto);

        Task<bool> AtualizarCategoriaAsync(int id, CategoriaCreateDTO dto);

        Task<bool> DeletarCategoriaAsync(int id);
    }
}