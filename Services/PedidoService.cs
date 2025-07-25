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
    public class PedidoService : IPedidoService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PedidoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> BuscarPedidoByIdAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return null;
            }
            return _mapper.Map<PedidoDTO>(pedido);
            
        }

        public async Task<PedidoDTO> CriarPedidoAsync(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return _mapper.Map<PedidoDTO>(pedido);
            
        }

        public async Task<bool> DeletePedidoAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PedidoDTO>> ListarPedidosAsync()
        {
            var pedidos = await _context.Pedidos.ToListAsync();
            return _mapper.Map<IEnumerable<PedidoDTO>>(pedidos);
            
        }

        public async Task<bool> UpdatePedidoAsync(int id, PedidoDTO pedidoUpdateDTO)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;
            _mapper.Map(pedidoUpdateDTO, pedido);
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}