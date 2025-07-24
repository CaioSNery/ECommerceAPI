using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.Dtos;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AtualizarCategoriaAsync(int id, CategoriaCreateDTO dto)
        {
            var categoria = await BuscarCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return false;
            }
            categoria.Nome = dto.Nome;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriaDTO> BuscarCategoriaByIdAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return null;
            }
            return _mapper.Map<CategoriaDTO>(categoria);

        }

        public async Task<CategoriaDTO> CriarCategoriaAsync(CategoriaCreateDTO dto)
        {
            var categoria = _mapper.Map<Categoria>(dto);
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<bool> DeletarCategoriaAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return false;
            }
            _context.Categorias.Remove(categoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CategoriaDTO>> ListarCategoriasAsync()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }
    }
}