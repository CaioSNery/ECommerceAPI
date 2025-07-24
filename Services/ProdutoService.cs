using System;
using System.Collections.Concurrent;
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
    public class ProdutoService : IProdutoService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProdutoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarProdutoAsync(int id, ProdutoCreateDTO dto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return false;
            }
            produto.Nome = dto.Nome;
            produto.PrecoVenda = dto.Preco;
            produto.Quantidade = dto.Estoque;
            produto.CategoriaId = dto.CategoriaId;

            _context.Produtos.Update(produto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ProdutoReadDTO> BuscarProdutoByIdAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return null;
            }
            return _mapper.Map<ProdutoReadDTO>(produto);
        }

        public async Task<ProdutoReadDTO> CriarProdutoAsync(ProdutoCreateDTO dto)
        {
            var produto = _mapper.Map<Produto>(dto);
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoReadDTO>(produto);
        }

        public async Task<bool> DeletarProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return false;
            }
            _context.Produtos.Remove(produto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ProdutoReadDTO>> ListarProdutosAsync()
        {
            return await _context.Produtos
                .Select(p => _mapper.Map<ProdutoReadDTO>(p))
                .ToListAsync();
        }
    }
}