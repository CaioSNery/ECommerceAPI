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
    public class CarrinhoService : ICarrinhoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarrinhoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CarrinhoDTO> CriarCarrinhoAsync(CarrinhoDTO carrinhoDTO)
        {
            var carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();
            return _mapper.Map<CarrinhoDTO>(carrinho);  
        }

        public async Task<IEnumerable<CarrinhoDTO>> ListarCarrinhosAsync()
        {
            var carrinhos = await _context.Carrinhos.ToListAsync();
            return _mapper.Map<IEnumerable<CarrinhoDTO>>(carrinhos);
        }
    }
}